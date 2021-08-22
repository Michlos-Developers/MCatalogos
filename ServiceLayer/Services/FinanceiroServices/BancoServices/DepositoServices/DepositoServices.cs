using DomainLayer.Models.Financeiro.Banco;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.DepositoServices
{
    public class DepositoServices : IDepositoRepository, IDepositoServices
    {
        private IDepositoRepository _depositoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DepositoServices(IDepositoRepository depositoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _depositoRepository = depositoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public DepositoModel Add(IDepositoModel deposito)
        {
            return _depositoRepository.Add(deposito);
        }

        public void CancelaRegistro(IDepositoModel deposito)
        {
            _depositoRepository.CancelaRegistro(deposito);
        }

        public IEnumerable<DepositoModel> GetAll()
        {
            return _depositoRepository.GetAll();
        }

        public IEnumerable<DepositoModel> GetAllByBanco(BancoModel banco)
        {
            return _depositoRepository.GetAllByBanco(banco);
        }

        public IEnumerable<DepositoModel> GetAllByData(DateTime data)
        {
            return _depositoRepository.GetAllByData(data);
        }

        public IEnumerable<DepositoModel> GetAllByDataAndBanco(DateTime data, BancoModel banco)
        {
            return _depositoRepository.GetAllByDataAndBanco(data, banco);
        }

        public IEnumerable<DepositoModel> GetAllByMonthAndYear(int month, int year)
        {
            return _depositoRepository.GetAllByMonthAndYear(month, year);
        }

        public IEnumerable<DepositoModel> GetAllByMonthYearBanco(int month, int year, BancoModel banco)
        {
            return _depositoRepository.GetAllByMonthYearBanco(month, year, banco);
        }

        public DepositoModel GetById(int depositoId)
        {
            return _depositoRepository.GetById(depositoId);
        }

        public void ValidateModel(IDepositoModel depositoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(depositoModel);
        }
    }
}
