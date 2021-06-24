using DomainLayer.Models.Produtos;

using ServiceLayer.CommonServices;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProdutoServices
{
    public class CampoTipoProdutoServices : ICampoTipoProdutoRepository, ICampoTipoProdutoServices
    {
        private ICampoTipoProdutoRepository _campoTipoProdutoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CampoTipoProdutoServices(ICampoTipoProdutoRepository campoTipoProdutoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _campoTipoProdutoRepository = campoTipoProdutoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public CampoTipoProdutoModel Add(ICampoTipoProdutoModel campo)
        {
            return _campoTipoProdutoRepository.Add(campo);
        }

        public void Delete(ICampoTipoProdutoModel campo)
        {
            _campoTipoProdutoRepository.Delete(campo);
        }

        public IEnumerable<CampoTipoProdutoModel> GetAll()
        {
            return _campoTipoProdutoRepository.GetAll();
        }

        public IEnumerable<CampoTipoProdutoModel> GetAllByFormatoId(int formatoCampoId)
        {
            return _campoTipoProdutoRepository.GetAllByFormatoId(formatoCampoId);
        }

        public IEnumerable<CampoTipoProdutoModel> GetAllByTipoProdutoId(int tipoPodutoId)
        {
            return _campoTipoProdutoRepository.GetAllByTipoProdutoId(tipoPodutoId);
        }

        public CampoTipoProdutoModel GetById(int campoTipoId)
        {
            return _campoTipoProdutoRepository.GetById(campoTipoId);
        }

        public CampoTipoProdutoModel GetByName(string campoName)
        {
            return _campoTipoProdutoRepository.GetByName(campoName);
        }

        public CampoTipoProdutoModel GetByNameAndFormatoId(string campoName, int formatoId)
        {
            return _campoTipoProdutoRepository.GetByNameAndFormatoId(campoName, formatoId);
        }

        public CampoTipoProdutoModel GetByNameAndTipoProdutoId(string campoName, int tipoProdutoId)
        {
            return _campoTipoProdutoRepository.GetByNameAndTipoProdutoId(campoName, tipoProdutoId);
        }

        public CampoTipoProdutoModel GetByTipoProdutoModel(TipoProdutoModel tipoProdutoModel)
        {
            return _campoTipoProdutoRepository.GetByTipoProdutoModel(tipoProdutoModel);
        }

        public void Update(ICampoTipoProdutoModel campo)
        {
            _campoTipoProdutoRepository.Update(campo);
        }

        public void ValidateModel(ICampoTipoProdutoModel campo)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(campo);
        }
    }
}
