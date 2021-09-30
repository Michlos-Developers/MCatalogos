using DomainLayer.Models.Financeiro.Banco;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.SaqueServices
{
    public interface ISaqueRepository
    {
        SaqueModel Add(ISaqueModel saqueModel);
        void CancelaRegistro(ISaqueModel saqueModel);
        SaqueModel GetById(int saqueId);
        IEnumerable<SaqueModel> GetAll();
        IEnumerable<SaqueModel> GetAllByMonthAndYear(int month, int year);
        IEnumerable<SaqueModel> GetAllByData(DateTime data);
        IEnumerable<SaqueModel> GetAllByConta(ContaModel conta);
        IEnumerable<SaqueModel> GetAllByDataAndConta(DateTime data, ContaModel conta);
        IEnumerable<SaqueModel> GetAllByMonthYearConta(int month, int year, ContaModel conta);
        
    }
}
