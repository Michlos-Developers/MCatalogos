using DomainLayer.Models.Financeiro.Banco;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices.ContaServices
{
    public interface IContaRepository
    {
        ContaModel AddConta(IContaModel conta);
        void RemoveConta(IContaModel conta);

        IEnumerable<ContaModel> GetAll();
        IEnumerable<ContaModel> GetAllByBanco(int bancoId);

        ContaModel GetById(int contaId);



    }
}
