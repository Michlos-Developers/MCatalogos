using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.TipoTelefoneServices
{
    public class TipoTelefoneServices : ITipoTelefoneRepository, ITipoTelefoneServices
    {
        //private ITipoTelefoneServices _tipoTelefoneServices;
        private ITipoTelefoneRepository _tipoTelefoneRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TipoTelefoneServices(ITipoTelefoneRepository tipoTelefoneRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoTelefoneModel> GetAll()
        {
            return _tipoTelefoneRepository.GetAll();
        }

        public TipoTelefoneModel GetById(int tipoTelefoneId)
        {
            return _tipoTelefoneRepository.GetById(tipoTelefoneId);
        }

        public TipoTelefoneModel GetByTipo(string tipoTelefone)
        {
            return _tipoTelefoneRepository.GetByTipo(tipoTelefone);
        }

        public void ValidateModel(ITipoTelefoneModel tipoTelefoneModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoTelefoneModel);
        }

        public void ValidateModelDataAnnotations(ITipoTelefoneModel tipoTelefoneModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoTelefoneModel);
        }
    }
}
