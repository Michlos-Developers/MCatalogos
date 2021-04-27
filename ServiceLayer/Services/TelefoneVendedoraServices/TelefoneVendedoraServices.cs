using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TelefoneVendedoraServices
{
    public class TelefoneVendedoraServices : ITelefoneVendedoraServices, ITelefoneVendedoraRepository
    {
        private ITelefoneVendedoraRepository _telefoneVendedoraRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TelefoneVendedoraServices(ITelefoneVendedoraRepository telefoneVendedoraRepository, 
            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _telefoneVendedoraRepository = telefoneVendedoraRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            _telefoneVendedoraRepository.Add(telefoneVendedoraModel);
        }

        public void Delete(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            _telefoneVendedoraRepository.Delete(telefoneVendedoraModel);
        }

        public IEnumerable<ITelefoneVendedoraModel> GetAll()
        {
            return _telefoneVendedoraRepository.GetAll();
        }

        public IEnumerable<ITelefoneVendedoraModel> GetByVendedoraId(int vendedoraId)
        {
            return _telefoneVendedoraRepository.GetByVendedoraId(vendedoraId);
        }

        public TelefoneVendedoraModel GetById(int id)
        {
            return _telefoneVendedoraRepository.GetById(id);
        }

        public void Update(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            _telefoneVendedoraRepository.Update(telefoneVendedoraModel);
        }

        public void ValidateMode(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telefoneVendedoraModel);
        }

        public void ValidateModelDataAnnotatios(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telefoneVendedoraModel);
        }
    }
}
