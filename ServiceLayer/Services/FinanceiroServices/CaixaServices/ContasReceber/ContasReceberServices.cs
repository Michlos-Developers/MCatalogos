using DomainLayer.Models.Financeiro.Caixa.ContasReceber;
using DomainLayer.Models.TitulosReceber;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasReceber
{
    public class ContasReceberServices : IContasReceberRepository, IContasReceberServices
    {
        private IContasReceberRepository _contasReceberRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasReceberServices(IContasReceberRepository contasReceberRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasReceberRepository = contasReceberRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ContasReceberModel Add(ContasReceberModel contasReceber)
        {
            return _contasReceberRepository.Add(contasReceber);
        }

        public void CancelaRegistro(ContasReceberModel contasReceber)
        {
            _contasReceberRepository.CancelaRegistro(contasReceber);
        }

        public IEnumerable<ContasReceberModel> GetAll()
        {
            return _contasReceberRepository.GetAll();
        }

        public IEnumerable<ContasReceberModel> GetAllByData(DateTime dataRegistro)
        {
            return _contasReceberRepository.GetAllByData(dataRegistro);
        }

        public IEnumerable<ContasReceberModel> GetAllByMonthAndYear(int month, int year)
        {
            return _contasReceberRepository.GetAllByMonthAndYear(month, year);
        }

        public IEnumerable<ContasReceberModel> GetAllByOrigem(TituloReceberModel origem)
        {
            return _contasReceberRepository.GetAllByOrigem(origem);
        }

        public ContasReceberModel GetById(int contasReceberId)
        {
            return _contasReceberRepository.GetById(contasReceberId);
        }

        public void ValidateModel(IContasReceberModel contasReceber)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contasReceber);
        }
    }
}
