using CommonComponents;

using DomainLayer.Models.CommonModels.Address;
using DomainLayer.Models.Vendedora;

using InfrastructureLayer.DataAccess.Repositories.Commons;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.EstadosServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests.Estado
{
    [Trait("Caregory: Data Access Validations", "Estado")]
    public class EstadoServicesDataAccessTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private EstadoServices _estadoServices;
        private string _connectionString;

        public EstadoServicesDataAccessTests(ITestOutputHelper testOutputHelper)
        {
            _connectionString = @"Server=.\SQLEXPRESS;database=MCatalogoDB;integrated security=SSPI;";
            _testOutputHelper = testOutputHelper;
            _estadoServices = new EstadoServices(new EstadoRepository(_connectionString), new ModelDataAnnotationCheck());
        }

        [Fact]
        public void ReturnListOfEstados()
        {
            List<EstadoModel> estadoModelList = (List<EstadoModel>)_estadoServices.GetAll();

            Assert.NotEmpty(estadoModelList);
            foreach (EstadoModel em  in estadoModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nEstadoId: {em.EstadoId}" +
                    $"\nNome: {em.Nome}" +
                    $"\nUf: {em.Uf}" +
                    $"\nCodIbge: {em.CodIbge}");
            }
        }

        [Fact]
        public void ReturnEstadoById()
        {
            EstadoModel estadoModel = null;
            int idToGet = 1;
            try
            {
                estadoModel = _estadoServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(estadoModel != null);
            Assert.True(idToGet == estadoModel.EstadoId);

            if (estadoModel != null)
            {
                string rotaModelJsonStr = JsonConvert.SerializeObject(estadoModel);
                string formattedJsonStr = JToken.Parse(rotaModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnEstadoByUf()
        {
            EstadoModel estadoModel = null;
            string ufToGet = "DF";
            try
            {
                estadoModel = _estadoServices.GetByUf(ufToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(estadoModel != null);
            Assert.True(ufToGet == estadoModel.Uf);

            if (estadoModel != null)
            {
                string rotaModelJsonStr = JsonConvert.SerializeObject(estadoModel);
                string formattedJsonStr = JToken.Parse(rotaModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }
    }
}
