using DomainLayer.Models.Financeiro.Caixa.ContasReceber;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasReceber
{
    public interface IContasReceberServices
    {
        void ValidateModel(IContasReceberModel contasReceber);
    }
}
