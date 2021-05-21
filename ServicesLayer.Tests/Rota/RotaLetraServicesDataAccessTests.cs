using CommonComponents;

using DomainLayer.Models.Vendedora;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.RotaServices;

using ServicesLayer.Tests.Bairro;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests.Rota
{
    [Trait("Category: Data Access", "RotaLetra")]
    public class RotaLetraServicesDataAccessTests
    {
        QueryString _queryString;
        private readonly ITestOutputHelper _testOutputHelper;
        private RotaLetraServices _rotaLetraServices;

        public RotaLetraServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _rotaLetraServices = new RotaLetraServices(new RotaLetraRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());

        }

        [Fact]
        public void ReturnForAddRotasLetras()
        {
            RotaLetraModel model = new RotaLetraModel()
            {
                RotaLetra = "B",
                //RotaLetraId = 1
            };
            bool operacaoSucedida = false;
            string dataAccessStatusJSonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _rotaLetraServices.Add(model);
                operacaoSucedida = true;
            }
            catch (DataAccessException e)
            {
                operacaoSucedida = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJSonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJSonStr).ToString();
            }

            try
            {
                Assert.True(operacaoSucedida);
                _testOutputHelper.WriteLine("Regi9stro adicionado com sucesso!");
            }
            finally
            {

                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnListOfRotasLetras()
        {
            List<RotaLetraModel> rotaLetraModelList = (List<RotaLetraModel>)_rotaLetraServices.GetAll();

            Assert.NotEmpty(rotaLetraModelList);
            foreach (RotaLetraModel rlm in rotaLetraModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nRotaLetraId: {rlm.RotaLetraId}" +
                    $"\nRotaLetra: {rlm.RotaLetra}");

            }
        }

        [Fact]
        public void ReturnRotaLetraById()
        {
            RotaLetraModel model = null;
            int idToGet = 1;
            try
            {
                model = _rotaLetraServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {
                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(model != null);
            Assert.True(idToGet == model.RotaLetraId);

            if (model != null)
            {
                string rotamodelJsonStr = JsonConvert.SerializeObject(model);
                string formattedJsonStr = JToken.Parse(rotamodelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }

        }

        [Fact]
        public void ReturnRotaLetraByLetra()
        {
            RotaLetraModel model = null;
            string letraToGet = "A";
            try
            {
                model = _rotaLetraServices.GetByLetra(letraToGet);
            }
            catch (DataAccessException e)
            {
                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());

            }

            Assert.True(model != null);
            Assert.True(letraToGet == model.RotaLetra);

            if (model != null)
            {
                string rotaLetraJsonStr = JsonConvert.SerializeObject(model);
                string formattedJsonStr = JToken.Parse(rotaLetraJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnRotaLetraForUpdate()
        {
            RotaLetraModel model = new RotaLetraModel()
            {
                RotaLetraId = 1,
                RotaLetra = "A"
            };

            bool sucessoOperacao = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _rotaLetraServices.Update(model);
                sucessoOperacao = true;
            }
            catch (DataAccessException e)
            {
                sucessoOperacao = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
                throw;
            }

            try
            {
                Assert.True(sucessoOperacao);
                _testOutputHelper.WriteLine("Registro atualizado com sucesso");

            }
            finally
            {

                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnRotaLetraForDelete()
        {
            RotaLetraModel model = new RotaLetraModel { RotaLetraId = 2 };

            bool operacaoSucedida = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formatteJsonStr = string.Empty;

            try
            {
                _rotaLetraServices.Delete(model);
                operacaoSucedida = true;
            }
            catch (DataAccessException e)
            {
                operacaoSucedida = e.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJsonStr = JsonConvert.SerializeObject(e.DataAccessStatusInfo);
                formatteJsonStr = JToken.Parse(dataAccessStatusJsonStr).ToString();
            }

            try
            {
                Assert.True(operacaoSucedida);
                _testOutputHelper.WriteLine("Registro apagado com sucesso.");
            }
            finally
            {
                _testOutputHelper.WriteLine(formatteJsonStr);
            }
        }


    }
}
