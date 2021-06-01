using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface ICampoTipoProdutoRepository
    {
        CampoTipoProdutoModel Add(ICampoTipoProdutoModel campo);
        void Update(ICampoTipoProdutoModel campo);
        void Delete(ICampoTipoProdutoModel campo);
        IEnumerable<CampoTipoProdutoModel> GetAll();
        IEnumerable<CampoTipoProdutoModel> GetAllByTipoProdutoId(int tipoPodutoId);

        IEnumerable<CampoTipoProdutoModel> GetAllByFormatoId(int formatoCampoId);
        
        CampoTipoProdutoModel GetById(int campoTipoId);
        CampoTipoProdutoModel GetByName(string campoName);
        CampoTipoProdutoModel GetByNameAndTipoProdutoId(string campoName, int tipoProdutoId);

        CampoTipoProdutoModel GetByNameAndFormatoId(string campoName, int formatoId);

        
        
    }
}
