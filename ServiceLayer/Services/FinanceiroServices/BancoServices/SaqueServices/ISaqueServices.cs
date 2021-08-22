using DomainLayer.Models.Financeiro.Banco;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.SaqueServices
{
    public interface ISaqueServices
    {
        void ValidateModel(ISaqueModel saqueModel);
    }
}
