using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.RotaServices
{
    public class RotaServices : IRotaServices, IRotaRepository
    {
        private IRotaRepository _rotaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public RotaServices(IRotaRepository rotaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _rotaRepository = rotaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;

        }

        public void Add(IRotaModel rotaModel)
        {
            _rotaRepository.Add(rotaModel);
        }

        public void Delete(IRotaModel rotaModel)
        {
            _rotaRepository.Delete(rotaModel);
        }

        public IEnumerable<IRotaModel> GetAll()
        {
            return _rotaRepository.GetAll();
        }

        public IEnumerable<IRotaModel> GetAllByLetraId(int letraId)
        {
            return _rotaRepository.GetAllByLetraId(letraId);
        }

        public RotaModel GetById(int id)
        {
            return _rotaRepository.GetById(id);
        }

        public RotaModel GetByNumeroAndLetraId(int numero, int letraId)
        {
            return _rotaRepository.GetByNumeroAndLetraId(numero, letraId);
        }

        public RotaModel GetByVendedoraId(int vendedoraId)
        {
            return _rotaRepository.GetByVendedoraId(vendedoraId);
        }

        public RotaModel GetLastNumero(int letraId)
        {
            return _rotaRepository.GetLastNumero(letraId);
        }

        public void RefatoraRotas(IRotaModel rotaInicial, int vendedoraQueEntra, List<RotaModel> rotaList, IRotaModel rotaAtual)
        {
            _rotaRepository.RefatoraRotas(rotaInicial, vendedoraQueEntra, rotaList, rotaAtual);
        }

        public void Update(IRotaModel rotaModel)
        {
            _rotaRepository.Update(rotaModel);
        }

        public void ValidateModel(IRotaModel rotaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(rotaModel);
        }

        public void ValidateModelDataAnno9tations(IRotaModel rotaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(rotaModel);
        }
    }
}
