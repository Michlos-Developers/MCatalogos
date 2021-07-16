using DomainLayer.Models.TitulosReceber;
using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.TitulosReceberServices
{
    public class TituloReceberServices : ITituloReceberRepository, ITituloReceberSerivces
    {
        private ITituloReceberRepository _tituloReceberRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TituloReceberServices(ITituloReceberRepository tituloReceberRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tituloReceberRepository = tituloReceberRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void AbaterValor(ITituloReceberModel tituloReceber, double valorAbatido)
        {
            _tituloReceberRepository.AbaterValor(tituloReceber, valorAbatido);
        }

        public ITituloReceberModel Add(ITituloReceberModel tituloReceber)
        {
            return _tituloReceberRepository.Add(tituloReceber);
        }

        public void Cancelar(ITituloReceberModel tituloReceber)
        {
            _tituloReceberRepository.Cancelar(tituloReceber);
        }

        public IEnumerable<ITituloReceberModel> GetAll()
        {
            return _tituloReceberRepository.GetAll();
        }

        public IEnumerable<ITituloReceberModel> GetAllByVendedora(IVendedoraModel vendedoraModel)
        {
            return _tituloReceberRepository.GetAllByVendedora(vendedoraModel);
        }

        public ITituloReceberModel GetById(int id)
        {
            return _tituloReceberRepository.GetById(id);
        }

        public void LiquidarTitulo(ITituloReceberModel tituloReceber)
        {
            _tituloReceberRepository.LiquidarTitulo(tituloReceber);
        }

        public void Protestar(ITituloReceberModel tituloReceber)
        {
            _tituloReceberRepository.Protestar(tituloReceber);
        }

        public void ValidateModel(ITituloReceberModel tituloReceber)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tituloReceber);
        }
    }
}
