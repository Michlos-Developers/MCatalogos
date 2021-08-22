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
        IEnumerable<DepositoModel> GetAllByBanco(BancoModel banco);
        IEnumerable<DepositoModel> GetAllByDataAndBanco(DateTime data, BancoModel banco);
        IEnumerable<DepositoModel> GetAllByMonthYearBanco(int month, int year, BancoModel banco);

    }
}
