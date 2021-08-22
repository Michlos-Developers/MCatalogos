using DomainLayer.Models.Financeiro.Caixa.ContasPagar;
using DomainLayer.Models.TitulosPagar;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasPagar
{
    public class ContasPagarServices : IContasPagarRepository, IContasPagarServices
    {
        private IContasPagarRepository _contasPagarRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;
        public ContasPagarModel Add(IContasPagarModel contasPagar)
        {
            return _contasPagarRepository.Add(contasPagar);
        }

        public void CancelaRegistro(IContasPagarModel contasPagar)
        {
            _contasPagarRepository.CancelaRegistro(contasPagar);
        }

        public IEnumerable<ContasPagarModel> GetAllByData(DateTime dataRegistro)
        {
            return _contasPagarRepository.GetAllByData(dataRegistro);
        }

        public IEnumerable<ContasPagarModel> GetAllByMonthAndYear(int month, int year)
        {
            return _contasPagarRepository.GetAllByMonthAndYear(month, year);
        }

        public IEnumerable<ContasPagarModel> GetAllByOrigem(ParcelaTituloPagar origem)
        {
            return _contasPagarRepository.GetAllByOrigem(origem);
        }

        public ContasPagarModel GetById(int contasPagarId)
        {
            return _contasPagarRepository.GetById(contasPagarId);
        }

        public void ValidateModel(IContasPagarModel contasPagar)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contasPagar);
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contasPagar);
        }
    }
}
