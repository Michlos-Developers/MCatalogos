using DomainLayer.Models.Formatos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.FormatoTamanhoServices
{
    public class FormatoTamanhoServices : IFormatoTamanhoRepository, IFormatoTamanhoServices
    {
        private IFormatoTamanhoRepository _formatoTamanhoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public FormatoTamanhoServices(IFormatoTamanhoRepository formatoTamanhoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _formatoTamanhoRepository = formatoTamanhoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public FormatosTamanhosModel Add(IFormatosTamanhosModel formatosTamanhosModel)
        {
            return _formatoTamanhoRepository.Add(formatosTamanhosModel);
        }

        public void Delete(IFormatosTamanhosModel formatosTamanhosModel)
        {
            _formatoTamanhoRepository.Delete(formatosTamanhosModel);
        }

        public IEnumerable<FormatosTamanhosModel> GetAll()
        {
            return _formatoTamanhoRepository.GetAll();
        }

        public FormatosTamanhosModel GetById(int formatoId)
        {
            return _formatoTamanhoRepository.GetById(formatoId);
        }

        public void Update(IFormatosTamanhosModel formatosTamanhosModel)
        {
            _formatoTamanhoRepository.Update(formatosTamanhosModel);
        }

        public void ValidateModel(IFormatosTamanhosModel formatosTamanhosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(formatosTamanhosModel);
        }

        public void ValidateModelDAtaAnnotations(IFormatosTamanhosModel formatosTamanhosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(formatosTamanhosModel);
        }
    }
}
