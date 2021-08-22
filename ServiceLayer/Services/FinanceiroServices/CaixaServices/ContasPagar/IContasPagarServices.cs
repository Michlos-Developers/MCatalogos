using DomainLayer.Models.Financeiro.Caixa.ContasPagar;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasPagar
{
    public interface IContasPagarServices
    {
        void ValidateModel(IContasPagarModel contasPagar);
    }
}
