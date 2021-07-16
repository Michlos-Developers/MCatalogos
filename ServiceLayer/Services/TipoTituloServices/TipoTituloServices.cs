using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.TipoTituloServices
{
    public class TipoTituloServices : ITipoTituloRepository, ITipoTituloServices
    {
        private ITipoTituloRepository _tipoTituloRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TipoTituloServices(ITipoTituloRepository tipoTituloRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tipoTituloRepository = tipoTituloRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoTituloModel> GetAll()
        {
            return _tipoTituloRepository.GetAll();
        }

        public TipoTituloModel GetById(int tipoTituloId)
        {
            return _tipoTituloRepository.GetById(tipoTituloId);
        }

        public TipoTituloModel GetByTipo(string tipoTitulo)
        {
            return _tipoTituloRepository.GetByTipo(tipoTitulo);
        }

        public void ValidateModel(ITipoTituloModel tipoTituloModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoTituloModel);
        }

        public void ValidateModelDataAnnotations(ITipoTituloModel tipoTituloModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoTituloModel);
        }
    }
}
