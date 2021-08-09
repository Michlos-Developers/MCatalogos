using DomainLayer.Models.Financeiro.Caixa;

namespace ServiceLayer.Services.FinanceiroServices.CaixaServices
{
    public interface ICaixaSerivces
    {
        void ValidateModel(ICaixaModel caixa);
    }
}
