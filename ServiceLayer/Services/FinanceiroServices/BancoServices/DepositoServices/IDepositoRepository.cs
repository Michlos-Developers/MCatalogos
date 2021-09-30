using DomainLayer.Models.Financeiro.Banco;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.DepositoServices
{
    public interface IDepositoRepository
    {
        DepositoModel Add(IDepositoModel deposito);
        void CancelaRegistro(IDepositoModel deposito);

        DepositoModel GetById(int depositoId);

        IEnumerable<DepositoModel> GetAll();
        IEnumerable<DepositoModel> GetAllByMonthAndYear(int month, int year);
        IEnumerable<DepositoModel> GetAllByData(DateTime data);
        IEnumerable<DepositoModel> GetAllByConta(ContaModel conta);
        IEnumerable<DepositoModel> GetAllByDataAndConta(DateTime data, ContaModel conta);
        IEnumerable<DepositoModel> GetAllByMonthYearConta(int month, int year, ContaModel conta);

    }
}
