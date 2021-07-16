using DomainLayer.Models.TitulosReceber;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.HistoricoTituloReceberServices
{
    public class HistoricoTituloReceberServices: IHistoricoTituloReceberRepository, IHistoricoTituloReceberServices
    {
        private IHistoricoTituloReceberRepository _historicoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public HistoricoTituloReceberServices(IHistoricoTituloReceberRepository historicoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _historicoRepository = historicoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IHistoricoTituloReceberModel Add(IHistoricoTituloReceberModel historico)
        {
            return _historicoRepository.Add(historico);
        }

        public IEnumerable<IHistoricoTituloReceberModel> GetAllByTitulo(ITituloReceberModel titulo)
        {
            return _historicoRepository.GetAllByTitulo(titulo);
        }

        public IHistoricoTituloReceberModel GetById(int historicoId)
        {
            return _historicoRepository.GetById(historicoId);
        }

        public void ValidateModel(IHistoricoTituloReceberModel historico)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(historico);
        }
    }
}
