using DomainLayer.Models.Financeiro.Banco;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.DepositoServices
{
    public interface IDepositoServices
    {
        void ValidateModel(IDepositoModel depositoModel);
    }
}
