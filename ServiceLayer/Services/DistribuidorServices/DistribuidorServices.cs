using DomainLayer.Models.Distribuidor;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DistribuidorServices
{
    public class DistribuidorServices : IDistribuidorRepository, IDistribuidorServices
    {
        private IDistribuidorRepository _distribuidorRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DistribuidorServices(IDistribuidorRepository distribuidorRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _distribuidorRepository = distribuidorRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public DistribuidorModel Add(IDistribuidorModel distribuidorModel)
        {
            return _distribuidorRepository.Add(distribuidorModel);
        }

        public DistribuidorModel GetModel()
        {
            return _distribuidorRepository.GetModel();
        }

        public void Update(IDistribuidorModel distribuidorModel)
        {
            _distribuidorRepository.Update(distribuidorModel);
        }

        public void ValidateModel(IDistribuidorModel distribuidorModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(distribuidorModel);
        }
    }
}
