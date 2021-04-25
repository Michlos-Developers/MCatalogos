using ServiceLayer.Services.RotaServices;
using ServiceLayer.CommonServices;
using DomainLayer.Models.Vendedora;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
using CommonComponents;
using System.Runtime.CompilerServices;

namespace ServicesLayer.Tests
{
    [Trait("Category Rota", "Data Access Validations")]
    public class RotaServicesDataAccessTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private RotaServices _rotaServices;
        private string _connectionString;

        public RotaServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _connectionString = "Data Source=" +
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MCatalogo\MCatalogo.sqlite;Verson= 3";
            _testOutputHelper = testOutputHelper;
            _rotaServices = new RotaServices(new RotaRepository(_connectionString), new ModelDataAnnotationCheck());

        }

        [Fact]
        public void SoludReturnListOfRotas()
        {
            List<RotaModel> rotaModelList = (List<RotaModel>)_rotaServices.GetAll();

            Assert.NotEmpty(rotaModelList);
            foreach (RotaModel rm in rotaModelList)
            {
                _testOutputHelper.WriteLine($""
                    + $"\nRotaId: {rm.RotaId}"
                    + $"\nLetra: {rm.Letra}"
                    + $"\nNumero: {rm.Numero}"
                    );
            }
        }

        [Fact]
        public void ShouldReturnRotaById()
        {
            RotaModel rotaModel = null;
            int idToGet = 1;
            try
            {
                rotaModel = _rotaServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(rotaModel != null);
            Assert.True(idToGet == rotaModel.RotaId);

            if (rotaModel != null)
            {
                string rotaModelJsonStr = JsonConvert.SerializeObject(rotaModel);
                string formattedJsonStr = JToken.Parse(rotaModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ShouldREturnSuccessForAdd()
        {
            RotaModel rm = new RotaModel()
            {
                Letra = "D",
                Numero = "01"
            };

            bool operationSucceeded = false;
            string dataAccessStatusJSonStr = string.Empty;
            string formattedJSonStr = string.Empty;

            try
            {
                _rotaServices.Add(rm);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJSonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJSonStr = JToken.Parse(dataAccessStatusJSonStr).ToString();
                
            }
            try
            {
                Assert.True(operationSucceeded);
                _testOutputHelper.WriteLine("The record was successfully added");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJSonStr);
            }
        }

        [Fact]
        public void ShouldREturnSuccessForUpdate()
        {
            RotaModel rm = new RotaModel()
            {
                RotaId = 1,
                Letra = "A",
                Numero = "10"
            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _rotaServices.Update(rm);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
            }

            try
            {
                Assert.True(operationSucceeded);
                _testOutputHelper.WriteLine("The record was successfully updated");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ShouldReturnSuccessForDelete()
        {
            RotaModel rm = new RotaModel { RotaId = 8 };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _rotaServices.Delete(rm);
                operationSucceeded = true;
            }
            catch (DataAccessException e)
            {
                operationSucceeded = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
            }

            try
            {
                Assert.True(operationSucceeded);
                _testOutputHelper.WriteLine("The record was successfully deleted");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }
    }
}
