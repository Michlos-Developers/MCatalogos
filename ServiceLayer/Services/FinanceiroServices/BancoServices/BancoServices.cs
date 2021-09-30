using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices
{
    public class BancoServices : IBancoRepository, IBancoServices
    {
        private IBancoRepository _bancoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public BancoServices(IBancoRepository bancoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _bancoRepository = bancoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public BancoModel AddBanco(IBancoModel banco)
        {
            return _bancoRepository.AddBanco(banco);
        }


        public IEnumerable<BancoModel> GetAll()
        {
            return _bancoRepository.GetAll();
        }

        public BancoModel GetById(int bancoId)
        {
            return _bancoRepository.GetById(bancoId);
        }

        public void RemoveBanco(IBancoModel banco)
        {
            _bancoRepository.RemoveBanco(banco);
        }

        public void ValidateModel(IBancoModel bancoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(bancoModel);
        }
    }
}
