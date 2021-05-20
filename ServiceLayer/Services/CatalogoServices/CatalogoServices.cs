using DomainLayer.Models.Catalogos;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CatalogoServices
{
    public class CatalogoServices : ICatalogoServices, ICatalogoRepository
    {
        private ICatalogoRepository _catalogoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CatalogoServices(ICatalogoRepository catalogoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _catalogoRepository = catalogoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public CatalogoModel Add(ICatalogoModel catalogoModel)
        {
            return _catalogoRepository.Add(catalogoModel);
        }

        public void Delete(ICatalogoModel catalogoModel)
        {
            _catalogoRepository.Delete(catalogoModel);
        }

        public IEnumerable<ICatalogoModel> GetAll()
        {
            return _catalogoRepository.GetAll();
        }

        public IEnumerable<ICatalogoModel> GetByFornecedorId(int fornecedorId)
        {
            return _catalogoRepository.GetByFornecedorId(fornecedorId);
        }

        public CatalogoModel GetById(int id)
        {
            return _catalogoRepository.GetById(id);
        }

        public void Update(ICatalogoModel catalogoModel)
        {
            _catalogoRepository.Update(catalogoModel);
        }

        public void ValidateMOdel(ICatalogoModel catalogoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(catalogoModel);
        }

        public void ValidataModelDAtaAnnotations(ICatalogoModel catalogoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(catalogoModel);
        }
    }
}
