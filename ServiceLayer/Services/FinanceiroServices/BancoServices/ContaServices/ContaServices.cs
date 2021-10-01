using DomainLayer.Models.Financeiro.Banco;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.ContaServices
{
    public class ContaServices : IContaRepository, IContaServices
    {
        private IContaRepository _contaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContaServices(IContaRepository contaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contaRepository = contaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ContaModel AddConta(IContaModel conta)
        {
            return _contaRepository.AddConta(conta);
        }

        public IEnumerable<ContaModel> GetAll()
        {
            return _contaRepository.GetAll();
        }

        public IEnumerable<ContaModel> GetAllByBanco(int bancoId)
        {
            return _contaRepository.GetAllByBanco(bancoId);
        }

        public ContaModel GetById(int contaId)
        {
            return _contaRepository.GetById(contaId);
        }

        public void RemoveConta(IContaModel conta)
        {
            _contaRepository.RemoveConta(conta);
        }

        public void ValidateModel(IContaModel contaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contaModel);
        }
    }
}
