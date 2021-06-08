using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface ITipoProdutoRepository
    {
        TipoProdutoModel Add(ITipoProdutoModel tipoProduto);
        void Update(ITipoProdutoModel tipoProduto);
        void Delete(ITipoProdutoModel tipoProduto);
        IEnumerable<TipoProdutoModel> GetAll();
        IEnumerable<TipoProdutoModel> GetByCatalogo(ICatalogoModel catalogo);
        TipoProdutoModel GetById(int tipoProdutoId);
        TipoProdutoModel GetByDescricao(string tipoProdutoName);


    }
}
