using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface IProdutoRepository
    {

        ProdutoModel AddWithMargens(IProdutoModel produto);
        void UpdateWithMargem(IProdutoModel produto);
        void Delete(IProdutoModel produto);
        IEnumerable<ProdutoModel> GetAll();
        IEnumerable<ProdutoModel> GetAllByCatalogoId(int catalogoId);
        IEnumerable<ProdutoModel> GetAllByCampanhaId(int campanhaId);
        ProdutoModel GetByReference(string Reference);
        ProdutoModel GetByCampanhaIdAndReference(int CampanhaId, string Reference);
        ProdutoModel GetById(int ProdutoId);
        ProdutoModel AddNoMargens(IProdutoModel produto);
        void UpdateNoMargem(IProdutoModel produto);
    }
}
