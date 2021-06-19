using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.EstoqueServices
{
    public class HistoricoEstoqueServices : IHistoricoEstoqueRepository, IHistorioEstoqueService
    {
        private IHistoricoEstoqueRepository _historicoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public HistoricoEstoqueServices(IHistoricoEstoqueRepository historicoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _historicoRepository = historicoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(IHistoricoEstoqueModel historicoModel)
        {
            _historicoRepository.Add(historicoModel);
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAll()
        {
            return _historicoRepository.GetAll();
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAllByEstoqueId(int estoqueId)
        {
            return _historicoRepository.GetAllByEstoqueId(estoqueId);
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAllByProduto(ProdutoModel produtoModel)
        {
            return _historicoRepository.GetAllByProduto(produtoModel);
        }

        public void ValidateModel(IHistoricoEstoqueModel historicoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(historicoModel);
        }

        public void ValidateModelDAtaAnnotations(IHistoricoEstoqueModel historicoEstoqueModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(historicoEstoqueModel);
        }
    }
}
