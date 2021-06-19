using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EstoqueServices
{
    public class EstoqueServices : IEstoqueRepository, IEstoqueService
    {
        private IEstoqueRepository _estoqueRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstoqueServices(IEstoqueRepository estoqueRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estoqueRepository = estoqueRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public EstoqueModel Add(IEstoqueModel estoqueModel)
        {
            return _estoqueRepository.Add(estoqueModel); 
        }

        public void Delete(IEstoqueModel estoqueModel)
        {
            _estoqueRepository.Delete(estoqueModel);
        }

        public IEnumerable<IEstoqueModel> GetAll()
        {
            return _estoqueRepository.GetAll();
        }

        public IEnumerable<IEstoqueModel> GetAllBayCatalogoAndCampanha(ICatalogoModel catalogoModel, ICampanhaModel campanhaModel)
        {
            return _estoqueRepository.GetAllBayCatalogoAndCampanha(catalogoModel, campanhaModel);
        }

        public IEnumerable<IEstoqueModel> GetAllByCatalogo(ICatalogoModel catalogoModel)
        {
            return _estoqueRepository.GetAllByCatalogo(catalogoModel);
        }

        public EstoqueModel GetById(int estoqueId)
        {
            return _estoqueRepository.GetById(estoqueId);
        }

        public EstoqueModel GetByProduto(IProdutoModel produtoModel)
        {
            return _estoqueRepository.GetByProduto(produtoModel);
        }

        public void Update(IEstoqueModel estoqueModel)
        {
            _estoqueRepository.Update(estoqueModel);
        }

        public void ValidateModel(IEstoqueModel estoqueModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estoqueModel);
        }

        public void ValidateModelDataAnnotations(IEstoqueModel estoqueModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estoqueModel);
        }
    }
}
