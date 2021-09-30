using DomainLayer.Models.Financeiro.Banco;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

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

        public IEnumerable<SaqueModel> GetAllByConta(ContaModel conta)
        {
            return _saqueRepository.GetAllByConta(conta);
        }

        public IEnumerable<SaqueModel> GetAllByData(DateTime data)
        {
            return _saqueRepository.GetAllByData(data);
        }

        public IEnumerable<SaqueModel> GetAllByDataAndConta(DateTime data, ContaModel conta)
        {
            return _saqueRepository.GetAllByDataAndConta(data, conta);
        }

        public IEnumerable<SaqueModel> GetAllByMonthAndYear(int month, int year)
        {
            return _saqueRepository.GetAllByMonthAndYear(month, year);
        }

        public IEnumerable<SaqueModel> GetAllByMonthYearConta(int month, int year, ContaModel conta)
        {
            return _saqueRepository.GetAllByMonthYearConta(month, year, conta);
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
