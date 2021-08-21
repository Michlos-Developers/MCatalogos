using DomainLayer.Models.Financeiro.Retirada;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.RetiradaServices
{
    public class RetiradaCaixaServices : IRetiradaCaixaRepository, IRetiradaCaixaSerivces
    {
        private IRetiradaCaixaRepository _retiradaCaixaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public RetiradaCaixaServices(IRetiradaCaixaRepository retiradaCaixaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _retiradaCaixaRepository = retiradaCaixaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public RetiradaCaixaModel Add(IRetiradaCaixaModel retiradaCaixa)
        {
            return _retiradaCaixaRepository.Add(retiradaCaixa);
        }

        public void CancelaRegistro(IRetiradaCaixaModel retiradaCaixa)
        {
            _retiradaCaixaRepository.CancelaRegistro(retiradaCaixa);
        }

        public IEnumerable<RetiradaCaixaModel> GetAll()
        {
            return _retiradaCaixaRepository.GetAll();
        }

        public RetiradaCaixaModel GetById(int retiradaId)
        {
            return _retiradaCaixaRepository.GetById(retiradaId);
        }

        public void ValidateModel(IRetiradaCaixaModel retiradaCaixa)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(retiradaCaixa);
        }
    }
}
