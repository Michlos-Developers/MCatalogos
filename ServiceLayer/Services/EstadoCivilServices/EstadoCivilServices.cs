

using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EstadoCivilServices
{
    public class EstadoCivilServices : IEstadoCivilRepository, IEstadoCivilServices
    {
        private IEstadoCivilRepository _estadoCivilRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstadoCivilServices(IEstadoCivilRepository estadoCivilRepository,
            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estadoCivilRepository = estadoCivilRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IEstadoCivilModel> GetAll()
        {
            return _estadoCivilRepository.GetAll();
        }
        public EstadoCivilModel GetById(int estadoCivilId)
        {
            return _estadoCivilRepository.GetById(estadoCivilId);
        }

        public EstadoCivilModel GetByEstadoCivil(string estadoCivil)
        {
            return _estadoCivilRepository.GetByEstadoCivil(estadoCivil);
        }

        public void ValidateModelDataAnnotations(IEstadoCivilModel estadoCivil)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estadoCivil);
        }

        public void ValidateModel(IEstadoCivilModel estadoCivil)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estadoCivil);
        }

    }
}
