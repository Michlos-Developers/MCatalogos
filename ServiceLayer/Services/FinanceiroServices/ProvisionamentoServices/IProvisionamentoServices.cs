using DomainLayer.Models.Financeiro.Provisionamento;

namespace ServiceLayer.Services.FinanceiroServices.ProvisionamentoServices
{
    public interface IProvisionamentoServices
    {
        void ValidateModel(IProvisionamentoModel provisionamento);
    }
}
