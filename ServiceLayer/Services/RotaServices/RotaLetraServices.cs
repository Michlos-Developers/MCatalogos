using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.RotaServices
{
    public class RotaLetraServices : IRotaLetraServices, IRotaLetraRepository
    {
        private IRotaLetraRepository _rotaLetraRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public RotaLetraServices(IRotaLetraRepository rotaLetraRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _rotaLetraRepository = rotaLetraRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(IRotaLetraModel rotaLetraModel)
        {
            _rotaLetraRepository.Add(rotaLetraModel);
        }

        public void Delete(IRotaLetraModel rotaLetraModel)
        {
            _rotaLetraRepository.Delete(rotaLetraModel);
        }

        public IEnumerable<IRotaLetraModel> GetAll()
        {
            return _rotaLetraRepository.GetAll();
        }

        public RotaLetraModel GetById(int id)
        {
            return _rotaLetraRepository.GetById(id);
        }

        public RotaLetraModel GetByLetra(string letra)
        {
            return _rotaLetraRepository.GetByLetra(letra);
        }

        public RotaLetraModel GetLastLetra()
        {
            return _rotaLetraRepository.GetLastLetra();
        }

        public void Update(IRotaLetraModel rotaLetraModel)
        {
            _rotaLetraRepository.Update(rotaLetraModel);
        }

        public void ValidateModel(IRotaLetraModel rotaLetraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(rotaLetraModel);
        }

        public void ValidateMOdelDataAnnotations(IRotaLetraModel rotaLetraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(rotaLetraModel);
        }
    }
}
