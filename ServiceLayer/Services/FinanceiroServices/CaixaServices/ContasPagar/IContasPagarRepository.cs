using DomainLayer.Models.Financeiro.Caixa.ContasPagar;
using DomainLayer.Models.TitulosPagar;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasPagar
{
    public interface IContasPagarRepository
    {
        ContasPagarModel Add(IContasPagarModel contasPagar);
        void CancelaRegistro(IContasPagarModel contasPagar);


        ContasPagarModel GetById(int contasPagarId);
        IEnumerable<ContasPagarModel> GetAllByMonthAndYear(int month, int year);
        IEnumerable<ContasPagarModel> GetAllByData(DateTime dataRegistro);
        IEnumerable<ContasPagarModel> GetAllByOrigem(ParcelaTituloPagar origem);
    }
}
