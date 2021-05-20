using DomainLayer.Models.Catalogos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.CatalogoServices
{
    public class CampanhaServices : ICampanhaServices, ICampanhaRepository
    {
        private ICampanhaRepository _campanhaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CampanhaServices(ICampanhaRepository campanhaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _campanhaRepository = campanhaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public CampanhaModel Add(ICampanhaModel campanhaModel)
        {
            return _campanhaRepository.Add(campanhaModel);
        }

        public void Delete(ICampanhaModel campanhaModel)
        {
            _campanhaRepository.Delete(campanhaModel);
        }

        public IEnumerable<ICampanhaModel> GetAll()
        {
            return _campanhaRepository.GetAll();
        }

        public IEnumerable<ICampanhaModel> GetByCatalogoId(int catalogoId)
        {
            return _campanhaRepository.GetByCatalogoId(catalogoId);
        }

        public CampanhaModel GetById(int campanhaId)
        {
            return _campanhaRepository.GetById(campanhaId);
        }

        public void Update(ICampanhaModel campanhaModel)
        {
            _campanhaRepository.Update(campanhaModel);
        }

        public void ValidateModel(ICatalogoModel catalogoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(catalogoModel);
        }

        public void ValidateModelDataAnnotations(ICampanhaModel campanhaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(campanhaModel);
        }
    }
}
