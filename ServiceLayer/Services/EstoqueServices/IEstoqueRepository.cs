using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.EstoqueServices
{
    public interface IEstoqueRepository
    {
        EstoqueModel Add(IEstoqueModel estoqueModel);
        void Update(IEstoqueModel estoqueModel);
        void Delete(IEstoqueModel estoqueModel);

        EstoqueModel GetById(int estqueId);
        EstoqueModel GetByProduto(IProdutoModel produtoModel);

        IEnumerable<IEstoqueModel> GetAll();
        IEnumerable<IEstoqueModel> GetAllByCatalogo(ICatalogoModel catalogoModel);
        IEnumerable<IEstoqueModel> GetAllByCatalogoCampanha(ICatalogoModel catalogoModel, ICampanhaModel campanhaModel);


    }
}
