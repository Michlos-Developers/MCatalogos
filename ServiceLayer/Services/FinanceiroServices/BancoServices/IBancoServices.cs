using DomainLayer.Models.Financeiro.Banco;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices
{
    public interface IBancoServices
    {
        void ValidateModel(IBancoModel bancoModel);
    }
}
