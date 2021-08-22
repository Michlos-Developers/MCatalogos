using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Retirada;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.SaqueServices
{
    public class SaqueServices : ISaqueRepository, ISaqueServices
    {
        private ISaqueRepository _saqueRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public SaqueServices(ISaqueRepository saqueRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _saqueRepository = saqueRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public SaqueModel Add(ISaqueModel saqueModel)
        {
            return _saqueRepository.Add(saqueModel);
        }

        public void CancelaRegistro(ISaqueModel saqueModel)
        {
            _saqueRepository.CancelaRegistro(saqueModel);
        }

        public IEnumerable<SaqueModel> GetAll()
        {
            return _saqueRepository.GetAll();
        }

        public IEnumerable<SaqueModel> GetAllByBanco(BancoModel banco)
        {
            return _saqueRepository.GetAllByBanco(banco);
        }

        public IEnumerable<SaqueModel> GetAllByData(DateTime data)
        {
            return _saqueRepository.GetAllByData(data);
        }

        public IEnumerable<SaqueModel> GetAllByDataAndBanco(DateTime data, BancoModel banco)
        {
            return _saqueRepository.GetAllByDataAndBanco(data, banco);
        }

        public IEnumerable<SaqueModel> GetAllByMonthAndYear(int month, int year)
        {
            return _saqueRepository.GetAllByMonthAndYear(month, year);
        }

        public IEnumerable<SaqueModel> GetAllByMonthYearBanco(int month, int year, BancoModel banco)
        {
            return _saqueRepository.GetAllByMonthYearBanco(month, year, banco);
        }

        public SaqueModel GetById(int saqueId)
        {
            return _saqueRepository.GetById(saqueId);
        }

        public void ValidateModel(ISaqueModel saqueModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(saqueModel);
        }
    }
}
