using DomainLayer.Models.Estoques;

namespace ServiceLayer.Services.EstoqueServices
{
    public interface IEstoqueService
    {
        void ValidateModel(IEstoqueModel estoqueModel);
    }
}
