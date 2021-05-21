using CommonComponents;

using DomainLayer.Models.CommonModels.Address;

using InfrastructureLayer;
using InfrastructureLayer.DataAccess.Repositories.Commons;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.BairroServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests.Bairro
{
    [Trait("Category: Data Access Validations", "Bairro")]
    public class BairroServicesDataAcessTests
    {
        QueryString _queryString;
        private readonly ITestOutputHelper _testOutputHelper;
        private BairroServices _bairroServices;

        public BairroServicesDataAcessTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _bairroServices = new BairroServices(new BairroRepository(_queryString.GetQuery()), new ModelDataAnnotationCheck());
        }

        [Fact]
        public void ReturnListFoBairros()
        {
            List<BairroModel> bairroModelList = (List<BairroModel>)_bairroServices.GetAll();
            Assert.NotEmpty(bairroModelList);
            foreach (BairroModel bm  in bairroModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nBairroId: {bm.BairroId}" +
                    $"\nNome: {bm.Nome}" +
                    $"\nCidadeId: {bm.CidadeId}");

            }
        }

        [Fact]
        public void ReturnListByCidadeId()
        {
            int cidadeIdToGet = 5570;
            List<BairroModel> bairroModelList = (List<BairroModel>)_bairroServices.GetByCidadeId(cidadeIdToGet);
            Assert.NotEmpty(bairroModelList);
            foreach (BairroModel bm in bairroModelList)
            {
                _testOutputHelper.WriteLine(
                    $"\nBairroId: {bm.BairroId}" +
                    $"\nNome: {bm.Nome}" +
                    $"\nCidadeId: {bm.CidadeId}");

            }
        }

        [Fact]
        public void ReturnListByNomeAndCidadeId()
        {
            int cidadeIdToGet = 5570;
            string nomeToGet = "Taguatinga";
            BairroModel bairroModel = null;

            try
            {
                bairroModel = _bairroServices.GetByNomeAndCidadeId(nomeToGet, cidadeIdToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(bairroModel != null);
            Assert.True(cidadeIdToGet == bairroModel.CidadeId);
            Assert.True(nomeToGet == bairroModel.Nome);

            if (bairroModel != null)
            {
                string bairroModelJsonStr = JsonConvert.SerializeObject(bairroModel);
                string formattedJsonStr = JToken.Parse(bairroModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }

        [Fact]
        public void ReturnModelById()
        {
            int idToGet = 5;
            BairroModel bairroModel = null;
            try
            {
                bairroModel = _bairroServices.GetById(idToGet);
            }
            catch (DataAccessException e)
            {

                _testOutputHelper.WriteLine(e.DataAccessStatusInfo.getFormattedValues());
            }

            Assert.True(bairroModel != null);
            Assert.True(idToGet == bairroModel.BairroId);

            if (bairroModel != null)
            {
                string bairroModelJsonStr = JsonConvert.SerializeObject(bairroModel);
                string formattedJsonStr = JToken.Parse(bairroModelJsonStr).ToString();
                _testOutputHelper.WriteLine(formattedJsonStr);
            }
        }


    }
}
