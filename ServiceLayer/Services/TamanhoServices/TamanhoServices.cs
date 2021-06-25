using DomainLayer.Models.Tamanho;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TamanhoServices
{
    public class TamanhoServices : ITamanhoRepository, ITamanhoServices
    {
        private ITamanhoRepository _tamanhoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TamanhoServices(ITamanhoRepository tamanhoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tamanhoRepository = tamanhoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public TamanhosModel Add(ITamanhosModel tamanhosModel)
        {
            return _tamanhoRepository.Add(tamanhosModel);
        }

        public void Delete(ITamanhosModel tamanhosModel)
        {
            _tamanhoRepository.Delete(tamanhosModel);
        }

        public IEnumerable<TamanhosModel> GetAll()
        {
            return _tamanhoRepository.GetAll();
        }

        public TamanhosModel GetById(int tamanhoId)
        {
            return _tamanhoRepository.GetById(tamanhoId);
        }

        public void Update(ITamanhosModel tamanhosModel)
        {
            _tamanhoRepository.Update(tamanhosModel);
        }

        public void ValidateModel(ITamanhosModel tamanhosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tamanhosModel);
        }

        public void VAlidateModelDataAnnotation(ITamanhosModel tamanhosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tamanhosModel);
        }
    }
}
