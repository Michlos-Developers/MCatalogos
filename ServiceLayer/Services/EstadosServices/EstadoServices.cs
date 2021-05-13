using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EstadosServices
{
    public class EstadoServices : IEstadosRepository, IEstadoServices
    {
        private IEstadosRepository _estadosRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstadoServices(IEstadosRepository estadosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estadosRepository = estadosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IEstadoModel> GetAll()
        {
            return _estadosRepository.GetAll();
        }

        public EstadoModel GetById(int estadoId)
        {
            return _estadosRepository.GetById(estadoId);
        }

        public EstadoModel GetByUf(string uf)
        {
            return _estadosRepository.GetByUf(uf);
        }

        public void ValidateModel(IEstadoModel estadoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estadoModel);
        }
    }
}
