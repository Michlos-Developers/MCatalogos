using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

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

        public BairroModel Add(IBairroModel bairroModel)
        {
            BairroModel bairroAdded = _bairroRepository.Add(bairroModel);
            return bairroAdded;
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
