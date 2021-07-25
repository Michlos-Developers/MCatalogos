using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.TitulosPagar;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.TitulosPagarServices
{
    public class TituloPagarServices : ITituloPagarRepository, ITituloPagarServices
    {
        private ITituloPagarRepository _tituloPagarRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TituloPagarServices(ITituloPagarRepository tituloPagarRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tituloPagarRepository = tituloPagarRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public TituloPagarModel Add(ITituloPagarModel tituloPagar)
        {
            return _tituloPagarRepository.Add(tituloPagar);
        }

        public void AddValorAdicional(double valorAdicional, ITituloPagarModel tituloPagar)
        {
            _tituloPagarRepository.AddValorAdicional(valorAdicional, tituloPagar);
        }

        public IEnumerable<TituloPagarModel> GetAll()
        {
            return _tituloPagarRepository.GetAll();
        }

        public IEnumerable<TituloPagarModel> GetAllByFornecedorId(int fornecedorId)
        {
            return _tituloPagarRepository.GetAllByFornecedorId(fornecedorId);
        }

        public TituloPagarModel GetById(int tituloId)
        {
            return _tituloPagarRepository.GetById(tituloId);
        }

        public void Liquidar(ITituloPagarModel tituloPagar)
        {
            _tituloPagarRepository.Liquidar(tituloPagar);
        }

        public void SetStatusTitulo(StatusTitulo status, ITituloPagarModel tituloPagar)
        {
            _tituloPagarRepository.SetStatusTitulo(status, tituloPagar);
        }

        public void ValidateModel(ITituloPagarModel tituloPagar)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tituloPagar);
        }
    }
}
