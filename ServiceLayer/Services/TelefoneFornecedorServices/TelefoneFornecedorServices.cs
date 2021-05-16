using DomainLayer.Models.Fornecedores;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TelefoneFornecedorServices
{
    public class TelefoneFornecedorServices : ITelefoneFornecedorServices, ITelefoneFornecedorRepository
    {
        private ITelefoneFornecedorRepository _telefoneFornecedorRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TelefoneFornecedorServices(ITelefoneFornecedorRepository telefoneFornecedorRepository, 
            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _telefoneFornecedorRepository = telefoneFornecedorRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            _telefoneFornecedorRepository.Add(telelefoneFornecedorModel);
        }

        public void Delete(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            _telefoneFornecedorRepository.Delete(telelefoneFornecedorModel);
        }

        public IEnumerable<ITelefoneFornecedorModel> GetAll()
        {
            return _telefoneFornecedorRepository.GetAll();
        }

        public IEnumerable<ITelefoneFornecedorModel> GetByFornecedorId(int fornecedorId)
        {
            return _telefoneFornecedorRepository.GetByFornecedorId(fornecedorId);
        }

        public TelefoneFornecedorModel GetById(int id)
        {
            return _telefoneFornecedorRepository.GetById(id);
        }

        public void Update(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            _telefoneFornecedorRepository.Update(telelefoneFornecedorModel);
        }

        public void ValidateModel(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telelefoneFornecedorModel);
        }

        public void ValidateModelDataAnnotatiosn(ITelefoneFornecedorModel telefoneFornecedorModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telefoneFornecedorModel);
        }
    }
}
