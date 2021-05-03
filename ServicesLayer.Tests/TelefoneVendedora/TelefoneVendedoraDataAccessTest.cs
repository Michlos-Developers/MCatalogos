using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ServicesLayer.Tests.TelefoneVendedora
{
    [Trait("Category: Data Access Validations", "Telefone Vendedora")]
    public class TelefoneVendedoraDataAccessTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private TelefoneVendedoraServices _telefoneVendedoraServices;
        private string _connectionString;

        public TelefoneVendedoraDataAccessTest(ITestOutputHelper testOutputHelper)
        {
            _connectionString = @"Server=.\SQLEXPRESS;database=MCatalogoDB;integrated security=SSPI;";
            _testOutputHelper = testOutputHelper;
            _telefoneVendedoraServices = new TelefoneVendedoraServices(new TelefoneVendedoraRepository(_connectionString), new ModelDataAnnotationCheck());

        }

        [Fact]
        public void ListOfTelefones()
        {
            List<TelefoneVendedoraModel> telefoneModelList = (List<TelefoneVendedoraModel>)_telefoneVendedoraServices.GetAll();

            Assert.NotEmpty(telefoneModelList);
            foreach (TelefoneVendedoraModel tvm in telefoneModelList)
            {
                _testOutputHelper.WriteLine($""
                    + $"\nTelefoneId: {tvm.TelefoneId}"
                    + $"\nNumero: {tvm.Numero}"
                    + $"\nTipoTelefoneId: {tvm.TipoTelefoneId}"
                    + $"\nVendedoraId: {tvm.VendedoraId}"
                    );
            }
        }

        [Fact]
        public void ReturnByTelefoneId()
        {
            TelefoneVendedoraModel telefoneModel = null;
            int idToGet = 1;

            try
            {
                telefoneModel = _telefoneVendedoraServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(telefoneModel != null);
            Assert.True(idToGet == telefoneModel.TelefoneId);

            if (telefoneModel != null)
            {
                string telefoneModelJsonStr = JsonConvert.SerializeObject(telefoneModel);
                string formattedJsonStr = JToken.Parse(telefoneModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnByVendedoraId()
        {
            int vendedoraIdToGet = 4;
            try
            {
                List<TelefoneVendedoraModel> telefoneModelList = (List<TelefoneVendedoraModel>)_telefoneVendedoraServices.GetByVendedoraId(vendedoraIdToGet);

                if (telefoneModelList.Count != 0)
                {
                    Assert.NotEmpty(telefoneModelList);
                    foreach (TelefoneVendedoraModel tvm in telefoneModelList)
                    {
                        _testOutputHelper.WriteLine($""
                            + $"\nTelefoneId: {tvm.TelefoneId}"
                            + $"\nNumero: {tvm.Numero}"
                            + $"\nTipoTelefoneId: {tvm.TipoTelefoneId}"
                            + $"\nVendedoraId: {tvm.VendedoraId}"
                            );
                    }
                }
                else
                {
                    _testOutputHelper.WriteLine($"Vendedora {vendedoraIdToGet} do not have Telefone");
                }
            }
            catch (DataAccessException e)
            {
                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }
        }

        [Fact]
        public void SuccessForAdd()
        {
            //TipoTelefoneModel tipoTelefone = null;
            TelefoneVendedoraModel tvm = new TelefoneVendedoraModel()
            {
                Numero = "6155554444",
                //TipoTelefoneId = int.Parse(new TipoTelefoneModel("Vivo").ToString()),
                TipoTelefoneId = 1,
                VendedoraId = 3,
            };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _telefoneVendedoraServices.Add(tvm);
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
                _testOutputHelper.WriteLine("The record was successfully added");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJsonStr);

            }
        }

        [Fact]
        public void SuccessForUpdate()
        {
            TelefoneVendedoraModel tvm = new TelefoneVendedoraModel()
            {
                TelefoneId = 2,
                Numero = "6155534441",
                TipoTelefoneId = 1,
                VendedoraId = 3
            };


            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _telefoneVendedoraServices.Update(tvm);
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
                _testOutputHelper.WriteLine("The record was successfully Updated");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void SuccessForDelete()
        {
            TelefoneVendedoraModel tvm = new TelefoneVendedoraModel { TelefoneId = 2 };

            bool operationSucceeded = false;
            string dataAccessStatusJsonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _telefoneVendedoraServices.Delete(tvm);
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
                _testOutputHelper.WriteLine("The record was successfully Deleted");
            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }


    }
}
