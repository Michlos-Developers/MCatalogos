using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public class TipoProdutoServices : ITipoProdutoRepository, ITipoProdutoServices
    {
        private ITipoProdutoRepository _tipoProdutoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TipoProdutoServices(ITipoProdutoRepository tipoProdutoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tipoProdutoRepository = tipoProdutoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public TipoProdutoModel Add(ITipoProdutoModel tipoProduto)
        {
            return _tipoProdutoRepository.Add(tipoProduto);
        }

        public void Delete(ITipoProdutoModel tipoProduto)
        {
            _tipoProdutoRepository.Delete(tipoProduto);
        }

        public IEnumerable<TipoProdutoModel> GetAll()
        {
            return _tipoProdutoRepository.GetAll();
        }

        public IEnumerable<TipoProdutoModel> GetByCatalogo(ICatalogoModel catalogo)
        {
            return _tipoProdutoRepository.GetByCatalogo(catalogo);
        }

        public TipoProdutoModel GetByDescricao(string tipoProdutoName)
        {
            return _tipoProdutoRepository.GetByDescricao(tipoProdutoName);
        }

        public TipoProdutoModel GetById(int tipoProdutoId)
        {
            return _tipoProdutoRepository.GetById(tipoProdutoId);
        }

        public void Update(ITipoProdutoModel tipoProduto)
        {
            _tipoProdutoRepository.Update(tipoProduto);
        }

        public void ValidateModel(ITipoProdutoModel tipoProduto)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoProduto);
        }
    }
}
