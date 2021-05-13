using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CidadeServices
{
    public class CidadeServices : ICidadeRepository, ICidadeServices
    {
        private ICidadeRepository _cidadeRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CidadeServices(ICidadeRepository cidadeRepository, 
            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _cidadeRepository = cidadeRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ICidadeModel> GetAll()
        {
            return _cidadeRepository.GetAll();
        }

        public IEnumerable<ICidadeModel> GetAllByEstadoId(int estadoId)
        {
            return _cidadeRepository.GetAllByEstadoId(estadoId);
        }

        public IEnumerable<ICidadeModel> GetAllByUf(string uf)
        {
            return _cidadeRepository.GetAllByUf(uf);
        }

        public CidadeModel GetById(int cidadeId)
        {
            return _cidadeRepository.GetById(cidadeId);
        }

        public CidadeModel GetByNome(string nome)
        {
            return _cidadeRepository.GetByNome(nome);
        }

        public CidadeModel GetByNomeAndEstadoId(string nome, int estadoId)
        {
            return _cidadeRepository.GetByNomeAndEstadoId(nome, estadoId);
        }

        public void ValidateDataAnnotations(ICidadeModel cidadeModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(cidadeModel);
        }
        public void ValidateModel(ICidadeModel cidadeModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(cidadeModel);
        }
    }
}
