using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using System.Collections.Generic;

namespace ServiceLayer.Services.TamanhoServices
{
    public interface ITamanhoRepository
    {
        TamanhosModel Add(ITamanhosModel tamanhosModel);
        void Update(ITamanhosModel tamanhosModel);
        void Delete(ITamanhosModel tamanhosModel);
        IEnumerable<TamanhosModel> GetAll();
        TamanhosModel GetById(int tamanhoId);
        IEnumerable<TamanhosModel> GetByProdutoModel(ProdutoModel produtoModel);
    }
}
