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
using InfrastructureLayer;

namespace ServicesLayer.Tests
{
    [Trait("Category: Data Access Validations", "Rota")]
    public class RotaServicesDataAccessTests
    {
        QueryString _queryString;
        private readonly ITestOutputHelper _testOutputHelper;
        private RotaServices _rotaServices;

        public RotaServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _rotaServices = new RotaServices(new RotaRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());

        }
        
        [Fact]
        public void ShouldReturnSuccessForAdd()
        {
            RotaModel rm = new RotaModel()
            {
                Numero = 1,
                RotaLetraId = 1,
                VendedoraId = 1
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
        public void SoludReturnListOfRotas()
        {
            List<RotaModel> rotaModelList = (List<RotaModel>)_rotaServices.GetAll();

            Assert.NotEmpty(rotaModelList);
            foreach (RotaModel rm in rotaModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nRotaId: {rm.RotaId}" +
                    $"\nNumero: {rm.Numero}" +
                    $"\nVendedoraId: {rm.VendedoraId}" +
                    $"\nRotaLetraId: {rm.RotaLetraId}"
                    );
            }
        }

        [Fact]
        public void ReturnSuccessForUpdate()
        {
            RotaModel rm = new RotaModel()
            {
                RotaId = 4,
                RotaLetraId = 1,
                Numero = 2,
                VendedoraId = 1
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
            RotaModel rm = new RotaModel { RotaId = 4 };

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

        [Fact]
        public void ReturnRotasByLetraId()
        {
            int idLetraToGet = 1;
            List<RotaModel> rotaModelList = (List<RotaModel>)_rotaServices.GetAllByLetraId(idLetraToGet);
            
            Assert.NotEmpty(rotaModelList);
            foreach (RotaModel rm in rotaModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nRotaId: {rm.RotaId}" +
                    $"\nNumero: {rm.Numero}" +
                    $"\nLetraId: {rm.RotaLetraId}" +
                    $"\nVendedoraId: {rm.VendedoraId}");

            }
        }

        [Fact]
        public void ReturnRotaById()
        {
            RotaModel rotaModel = null;
            int idToGet = 5;
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
        public void ReturnByNumeroAndLetraId()
        {
            RotaModel model = null;
            int numeroToGet = 1;
            int letraIdToGet = 1;
            try
            {
                model = _rotaServices.GetByNumeroAndLetraId(numeroToGet, letraIdToGet);
            }
            catch (DataAccessException e)
            {
                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(model != null);
            Assert.True(numeroToGet == model.Numero);
            Assert.True(letraIdToGet == model.RotaLetraId);

            if (model!=null)
            {
                string modelJasonStr = JsonConvert.SerializeObject(model);
                string formattedJsonStr = JToken.Parse(modelJasonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }



        
    }
}
