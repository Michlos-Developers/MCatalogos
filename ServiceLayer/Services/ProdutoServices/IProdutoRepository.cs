using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface IProdutoRepository
    {

        ProdutoModel Add(IProdutoModel produto);
        void Update(IProdutoModel produto);
        void Delete(IProdutoModel produto);
        IEnumerable<ProdutoModel> GetAll();
        IEnumerable<ProdutoModel> GetAllByCatalogoId(int catalogoId);
        IEnumerable<ProdutoModel> GetAllByCampanhaId(int campanhaId);
        IEnumerable<ProdutoModel> GetAllByTipoId(int tipoProdutoId);
        IEnumerable<ProdutoModel> GetAllByCampanhaIdAndTipoId(int CampanhaId, int TipoProdutoId);
        ProdutoModel GetByReference(string Reference);
        ProdutoModel GetByCampanhaIdAndReference(int CampanhaId, string Reference);
        ProdutoModel GetById(int ProdutoId);
    }
}
