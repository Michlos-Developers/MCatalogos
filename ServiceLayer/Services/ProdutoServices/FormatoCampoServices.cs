using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public class FormatoCampoServices : IFormatoCampoRepository, IFormatoModelServices
    {
        private IFormatoCampoRepository _formatoCampoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public FormatoCampoServices(IFormatoCampoRepository formatoCampoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _formatoCampoRepository = formatoCampoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IFormatoCampoModel> GetAll()
        {
            return _formatoCampoRepository.GetAll();
        }

        public FormatoCampoModel GetById(int formatoId)
        {
            return _formatoCampoRepository.GetById(formatoId);
        }

        public FormatoCampoModel GetByNome(string nomeFormato)
        {
            return _formatoCampoRepository.GetByNome(nomeFormato);
        }

        public void ValidateModel(IFormatoCampoModel formatoCampo)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(formatoCampo);
        }
    }
}
