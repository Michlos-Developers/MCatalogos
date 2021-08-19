using DomainLayer.Models.Financeiro.Retirada;

namespace ServiceLayer.Services.FinanceiroServices.RetiradaServices
{
    public interface IRetiradaCaixaSerivces
    {
        void ValidateModel(IRetiradaCaixaModel retiradaCaixa);
    }
}
