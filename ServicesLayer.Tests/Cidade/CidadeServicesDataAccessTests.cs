using CommonComponents;

using DomainLayer.Models.CommonModels.Address;

using InfrastructureLayer.DataAccess.Repositories.Commons;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.CidadeServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests.Cidade
{
    [Trait("Category: Data Access Validations", "Cidade")]

    public class CidadeServicesDataAccessTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private CidadeServices _cidadeServices;
        private string _connectionString;

        public CidadeServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _connectionString = @"Server=.\SQLEXPRESS;database=MCatalogoDB;integrated security=SSPI;";
            _testOutputHelper = testOutputHelper;
            _cidadeServices = new CidadeServices(new CidadeRepository(_connectionString), new ModelDataAnnotationCheck());
        }

        [Fact]
        public void ReturnListOfCidades()
        {
            List<CidadeModel> cidadeModelList = (List<CidadeModel>)_cidadeServices.GetAll();

            Assert.NotEmpty(cidadeModelList);
            foreach (CidadeModel cm  in cidadeModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nCidadeId: {cm.CidadeId}" +
                    $"\nNome: {cm.Nome}" +
                    $"\nUf: {cm.Uf}" +
                    $"\nCodIbge: {cm.CodIbge}" +
                    $"\nEstadoId: {cm.EstadoId}");

            }
        }

        [Fact]
        public void ReturnListByEstadoId()
        {
            int estadoIdToGet = 11;
            List<CidadeModel> cidadeModelList = (List<CidadeModel>)_cidadeServices.GetAllByEstadoId(estadoIdToGet);

            Assert.NotEmpty(cidadeModelList);
            foreach (CidadeModel cidadeModel in cidadeModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nCidadeId: {cidadeModel.CidadeId}" +
                    $"\nNome: {cidadeModel.Nome}" +
                    $"\nUf: {cidadeModel.Uf}" +
                    $"\nCodIbge: {cidadeModel.CodIbge}" +
                    $"\nEstadoId: {cidadeModel.EstadoId}");

            }
        }

        [Fact]
        public void ReturnListByUf()
        {
            string ufToGet = "GO";
            List<CidadeModel> cidadeModelList = (List<CidadeModel>)_cidadeServices.GetAllByUf(ufToGet);

            Assert.NotEmpty(cidadeModelList);
            foreach (CidadeModel cm  in cidadeModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nCidadeId: {cm.CidadeId}" +
                    $"\nNome: {cm.Nome}" +
                    $"\nUf: {cm.Uf}" +
                    $"\nCodIbge: {cm.CodIbge}" +
                    $"\nEstadoId: {cm.EstadoId}");
            }
        }

        [Fact]
        public void ReturnCidadeById()
        {
            CidadeModel cidadeModel = null;
            int idToGet = 20;

            try
            {
                cidadeModel = _cidadeServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(cidadeModel != null);
            Assert.True(idToGet == cidadeModel.CidadeId);

            if (cidadeModel != null)
            {
                string cidadeModelJsonStr = JsonConvert.SerializeObject(cidadeModel);
                string formattedJsonStr = JToken.Parse(cidadeModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

    }
}
