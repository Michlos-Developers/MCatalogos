using DomainLayer.Models.Estoques;

namespace ServiceLayer.Services.EstoqueServices
{
    public interface IHistorioEstoqueService
    {
        void ValidateModel(IHistoricoEstoqueModel historicoModel);
    }
}
