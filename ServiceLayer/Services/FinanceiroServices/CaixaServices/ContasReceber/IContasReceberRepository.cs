using DomainLayer.Models.Financeiro.Caixa.ContasReceber;
using DomainLayer.Models.TitulosReceber;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasReceber
{
    public interface IContasReceberRepository
    {
        ContasReceberModel Add(ContasReceberModel contasReceber);
        void CancelaRegistro(ContasReceberModel contasReceber);
        ContasReceberModel GetById(int contasReceberId);
        IEnumerable<ContasReceberModel> GetAll();
        IEnumerable<ContasReceberModel> GetAllByMonthAndYear(int month, int year);
        IEnumerable<ContasReceberModel> GetAllByData(DateTime dataRegistro);
        IEnumerable<ContasReceberModel> GetAllByOrigem(TituloReceberModel origem);

    }
}
