using DomainLayer.Models.Financeiro.Banco;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.ContaServices
{
    public interface IContaServices
    {
        void ValidateModel(IContaModel contaModel);
    }
}
