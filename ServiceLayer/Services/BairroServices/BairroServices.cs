using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.BairroServices
{
    public class BairroServices : IBairroRepository, IBairroServices
    {
        private IBairroRepository _bairroRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public BairroServices(IBairroRepository bairroRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _bairroRepository = bairroRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public BairroModel GetByNomeAndCidadeId(string nome, int cidadeId)
        {
            return _bairroRepository.GetByNomeAndCidadeId(nome, cidadeId);
        }

        public void Add(IBairroModel bairroModel)
        {
            _bairroRepository.Add(bairroModel);
        }

        public void Delete(IBairroModel bairroModel)
        {
            _bairroRepository.Delete(bairroModel);
        }

        public IEnumerable<IBairroModel> GetAll()
        {
            return _bairroRepository.GetAll();
        }

        public IEnumerable<IBairroModel> GetByCidadeId(int cidadeId)
        {
            return _bairroRepository.GetByCidadeId(cidadeId);
        }

        public BairroModel GetById(int id)
        {
            return _bairroRepository.GetById(id);
        }

        public void Update(IBairroModel bairroModel)
        {
            _bairroRepository.Update(bairroModel);
        }

        public void ValidateModelDataAnnotations(IBairroModel bairroModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(bairroModel);
        }

        public void ValidateModel(IBairroModel bairroModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(bairroModel);
        }
    }
}
