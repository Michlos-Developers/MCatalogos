using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public class ProdutoServices : IProdutoRepository, IProdutoServices
    {
        private IProdutoRepository _produtoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ProdutoServices(IProdutoRepository produtoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _produtoRepository = produtoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ProdutoModel Add(IProdutoModel produto)
        {
            return _produtoRepository.Add(produto);
        }

        public void Delete(IProdutoModel produto)
        {
            _produtoRepository.Delete(produto);
        }

        public IEnumerable<ProdutoModel> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public IEnumerable<ProdutoModel> GetAllByCampanhaId(int campanhaId)
        {
            return _produtoRepository.GetAllByCampanhaId(campanhaId);
        }


        public IEnumerable<ProdutoModel> GetAllByCatalogoId(int catalogoId)
        {
            return _produtoRepository.GetAllByCatalogoId(catalogoId);
        }


        public ProdutoModel GetByCampanhaIdAndReference(int CampanhaId, string Reference)
        {
            return _produtoRepository.GetByCampanhaIdAndReference(CampanhaId, Reference);
        }

        public ProdutoModel GetById(int ProdutoId)
        {
            return _produtoRepository.GetById(ProdutoId);
        }

        public ProdutoModel GetByReference(string Reference)
        {
            return _produtoRepository.GetByReference(Reference);
        }

        public void Update(IProdutoModel produto)
        {
            _produtoRepository.Update(produto);
        }

        public void ValidateModel(IProdutoModel produto)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(produto);
        }
    }
}
