using DomainLayer.Models.Financeiro.Caixa;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices
{
    public interface ICaixaRepository
    {
        CaixaModel AddValue(ICaixaModel caixa);
        CaixaModel RemoveValue(ICaixaModel caixa);

        CaixaModel GetById(int caixaId);

        double GetSaldo(); //Praticamente o last
        CaixaModel GetLast(ICaixaModel caixa);
        IEnumerable<CaixaModel> GetAll();
        IEnumerable<CaixaModel> GetAllByMonthAndYear(int month, int year);

    }
}
