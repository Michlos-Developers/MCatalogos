using DomainLayer.Models.Financeiro.Caixa;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices
{
    public class CaixaServices : ICaixaRepository, ICaixaSerivces
    {
        private ICaixaRepository _caixaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CaixaServices(ICaixaRepository caixaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _caixaRepository = caixaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public CaixaModel AddValue(ICaixaModel caixa)
        {
            return _caixaRepository.AddValue(caixa);
        }

        public void CancelaRegistro(ICaixaModel caixa)
        {
            _caixaRepository.CancelaRegistro(caixa);
        }

        public IEnumerable<CaixaModel> GetAll()
        {
            return _caixaRepository.GetAll();
        }

        public IEnumerable<CaixaModel> GetAllByMonthAndYear(int month, int year)
        {
            return _caixaRepository.GetAllByMonthAndYear(month, year);
        }

        public CaixaModel GetById(int caixaId)
        {
            return _caixaRepository.GetById(caixaId);
        }

        public CaixaModel GetLast()
        {
            return _caixaRepository.GetLast();
        }

        public double GetSaldo()
        {
            return _caixaRepository.GetLast().SaldoAtual;
        }

        public CaixaModel RemoveValue(ICaixaModel caixa)
        {
            return _caixaRepository.RemoveValue(caixa);
        }

        public void ValidateModel(ICaixaModel caixa)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(caixa);
        }
    }
}
