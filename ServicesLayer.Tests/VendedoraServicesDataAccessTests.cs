using CommonComponents;

using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    [Trait("Category: Data Access Validations", "Vendedora")]
    public class VendedoraServicesDataAccessTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private VendedoraServices _vendedoraServices;
        private string _connectionString;

        public VendedoraServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _connectionString = "Data Source=" +
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MCatalogo\MCatalogo.sqlite;Version= 3;";
            _testOutputHelper = testOutputHelper;
            _vendedoraServices = new VendedoraServices(new VendedoraRepository(_connectionString), new ModelDataAnnotationCheck());
        }

        [Fact]
        public void ShouldReturnListOfVendedoras()
        {
            List<VendedoraModel> vendedoraModelList = (List<VendedoraModel>)_vendedoraServices.GetAll();

            Assert.NotEmpty(vendedoraModelList);

            foreach (VendedoraModel vm in vendedoraModelList)
            {
                _testOutputHelper.WriteLine($""
                    + $"\nVendedoraId: {vm.VendedoraId}"
                    + $"\nNome: {vm.Nome}"
                    + $"\nCpf: {vm.Cpf}"
                    + $"\nEmail: {vm.Email}"
                    + $"\nRotaId: {vm.RotaId}"
                    + $"\nRota: {vm.Rota.RotaId}-{vm.Rota.Letra}/{vm.Rota.Numero}"
                    );
            }
        }

        [Fact]
        public void ShouldReturnVendedoraModelMatchingId()
        {
            VendedoraModel vendedoraModel = null;
            int idToGet = 10;
            try
            {
                vendedoraModel = _vendedoraServices.GetById(idToGet);
            }
            catch (DataAccessException dae)
            {
                _testOutputHelper.WriteLine(dae.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(vendedoraModel != null);
            Assert.True(idToGet == vendedoraModel.VendedoraId);

            if (vendedoraModel != null)
            {
                string vendedoraModelJsonStr = JsonConvert.SerializeObject(vendedoraModel);
                string formattedJsonStr = JToken.Parse(vendedoraModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ShouldReturnSuccessForAdd()
        {
            
            
            VendedoraModel vm = new VendedoraModel()
            {
                Nome = "11 UnitTest With Adress Complete",
                Cpf = "12345678922",
                Rg = "12345655",
                RgEmissor = "SSP",
                UfRgId = 1,
                DataNascimento = new DateTime(1952, 09, 15),
                Email = "unit11@teste.com",
                Logradouro = "QSC 3, Bloco B",
                Numero = "SN",
                Complemento = "Apto. 102",
                Cep = "72000000",
                EstadoCivilId = 1,
                EstadoId = 1,
                CidadeId = 1,
                BairroId = 1,
                //RotaId = 7


            };

            bool operationSucceeded = false;
            string dataAccessStatusJSonStr = string.Empty;
            string formattedJsonStr = string.Empty;

            try
            {
                _vendedoraServices.Add(vm);
                operationSucceeded = true;
            }
            catch (DataAccessException dataAccessException)
            {
                operationSucceeded = dataAccessException.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJSonStr = JsonConvert.SerializeObject(dataAccessException.DataAccessStatusInfo);
                formattedJsonStr = JToken.Parse(dataAccessStatusJSonStr).ToString();
                //throw;
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
        public void ShouldReturnSuccessForUpdate()
        {
            VendedoraModel vm = new VendedoraModel()
            {
                VendedoraId = 10,
                Nome = "UnitTest With With Address Updatated",
                Cpf = "32165498725",
                Rg = "65498752",
                RgEmissor = "SSP",
                UfRgId = 1,
                DataNascimento = new DateTime(1952, 09, 15),
                Email = "unit10@teste.com",
                Logradouro = "QSC 3 Bloco B",
                Numero = "SN",
                Complemento = "Apto 102",
                Cep = "71805703",
                EstadoCivilId = 1,
                EstadoId = 27,
                CidadeId = 1,
                BairroId = 1,
                RotaId = 7
            };

            bool operationSucceeded = false;
            string dataAccessStatusJSonStr = string.Empty;
            string formattedJSonStr = string.Empty;

            try
            {
                _vendedoraServices.Update(vm);
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
                _testOutputHelper.WriteLine("The record was successfuly updated");
            }
            finally
            {

                _testOutputHelper.WriteLine(formattedJSonStr);
            }
        }

        [Fact]
        public void ShouldReturnSuccessForDelete()
        {
            VendedoraModel vm = new VendedoraModel() { VendedoraId = 11 };

            bool operationSucceeded = false;
            string dataAccessStatusJSonStr = string.Empty;
            string formattedJSonStr = string.Empty;


            try
            {
                _vendedoraServices.Delete(vm);
                operationSucceeded = true;
            }
            catch (DataAccessException dae)
            {
                operationSucceeded = dae.DataAccessStatusInfo.OperationSucceeded;
                dataAccessStatusJSonStr = JsonConvert.SerializeObject(dae.DataAccessStatusInfo);
                formattedJSonStr = JToken.Parse(dataAccessStatusJSonStr).ToString();

            }


            try
            {
                Assert.True(operationSucceeded);
                _testOutputHelper.WriteLine("The record was successfully deleted");

            }
            finally
            {
                _testOutputHelper.WriteLine(formattedJSonStr);
            }
        }

    }
}
