using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.EstoqueServices
{
    public interface IHistoricoEstoqueRepository
    {
        void Add(IHistoricoEstoqueModel historicoModel);
        IEnumerable<IHistoricoEstoqueModel> GetAll();
        IEnumerable<IHistoricoEstoqueModel> GetAllByEstoqueId(int estoqueId);
        IEnumerable<IHistoricoEstoqueModel> GetAllByProduto(ProdutoModel produtoModel);
    }
}
