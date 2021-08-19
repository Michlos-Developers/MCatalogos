using DomainLayer.Models.Financeiro.Retirada;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.RetiradaServices
{
    public interface IRetiradaCaixaRepository
    {
        RetiradaCaixaModel Add(IRetiradaCaixaModel retiradaCaixa);
        void CancelaRegistro(IRetiradaCaixaModel retiradaCaixa);

        IEnumerable<RetiradaCaixaModel> GetAll();
        RetiradaCaixaModel GetById(int retiradaId);
    }
}
