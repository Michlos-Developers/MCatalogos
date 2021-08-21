using DomainLayer.Models.Financeiro.Provisionamento;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.ProvisionamentoServices
{
    public interface IProvisionamentoRepository
    {
        ProvisionamentoModel AddValue(IProvisionamentoModel provisionamento);
        void RemoveValue(IProvisionamentoModel provisionamento);
        void CancelaRegistro(IProvisionamentoModel provisionamento);
        ProvisionamentoModel GetById(int provisionamentoId);
        IEnumerable<ProvisionamentoModel> GetAll();
        IEnumerable<ProvisionamentoModel> GetAllByMonthAndYear(int month, int year);
        IEnumerable<ProvisionamentoModel> GetAllByData(DateTime date);

    }
}
