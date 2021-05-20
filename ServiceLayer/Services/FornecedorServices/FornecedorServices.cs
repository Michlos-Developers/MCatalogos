using DomainLayer.Models.Fornecedores;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.FornecedorServices
{
    public class FornecedorServices : IFornecedorService, IFornecedorRepository
    {
        private IFornecedorRepository _fornecedorRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public FornecedorServices(IFornecedorRepository fornecedorRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _fornecedorRepository = fornecedorRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public FornecedorModel Add(IFornecedorModel fornecedorModel)
        {
            return _fornecedorRepository.Add(fornecedorModel);
        }

        public void Delete(IFornecedorModel fornecedorModel)
        {
            _fornecedorRepository.Delete(fornecedorModel);
        }

        public IEnumerable<IFornecedorModel> GetAll()
        {
            return _fornecedorRepository.GetAll();
        }

        public FornecedorModel GetById(int fornecedorId)
        {
            return _fornecedorRepository.GetById(fornecedorId);
        }

        public FornecedorModel GetByNomeFantasia(string nomeFantasia)
        {
            return _fornecedorRepository.GetByNomeFantasia(nomeFantasia);
        }

        public void Update(IFornecedorModel fornecedorModel)
        {
            _fornecedorRepository.Update(fornecedorModel);
        }

        public void ValidateModel(IFornecedorModel fornecedorModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(fornecedorModel);
        }

        public void VAlidateModelDataAnnotations(IFornecedorModel fornecedorModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(fornecedorModel);
        }
    }
}
