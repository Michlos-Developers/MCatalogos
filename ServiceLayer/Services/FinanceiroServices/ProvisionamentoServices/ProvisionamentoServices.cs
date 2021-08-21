using DomainLayer.Models.Financeiro.Provisionamento;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.ProvisionamentoServices
{
    public class ProvisionamentoServices : IProvisionamentoRepository, IProvisionamentoServices
    {
        private IProvisionamentoRepository _provisionamentoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ProvisionamentoServices(IProvisionamentoRepository provisionamentoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _provisionamentoRepository = provisionamentoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ProvisionamentoModel AddValue(IProvisionamentoModel provisionamento)
        {
            return _provisionamentoRepository.AddValue(provisionamento);
        }

        public void CancelaRegistro(IProvisionamentoModel provisionamento)
        {
            _provisionamentoRepository.CancelaRegistro(provisionamento);
        }

        public IEnumerable<ProvisionamentoModel> GetAll()
        {
            return _provisionamentoRepository.GetAll();
        }

        public IEnumerable<ProvisionamentoModel> GetAllByData(DateTime date)
        {
            return _provisionamentoRepository.GetAllByData(date);
        }

        public IEnumerable<ProvisionamentoModel> GetAllByMonthAndYear(int month, int year)
        {
            return _provisionamentoRepository.GetAllByMonthAndYear(month, year);
        }

        public ProvisionamentoModel GetById(int provisionamentoId)
        {
            return _provisionamentoRepository.GetById(provisionamentoId);
        }

        public void RemoveValue(IProvisionamentoModel provisionamento)
        {
            _provisionamentoRepository.RemoveValue(provisionamento);
        }

        public void ValidateModel(IProvisionamentoModel provisionamento)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(provisionamento);
        }
    }
}
