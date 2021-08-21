using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices.BancoServices
{
    public interface IBancoRepository
    {
        BancoModel AddBanco(IBancoModel banco);
        void RemoveBanco(IBancoModel banco);
        BancoModel AtualizaSaldo(IBancoModel banco, double valorRegistro, TipoMovimentacao tipoMovimentacao);

        IEnumerable<BancoModel> GetAll();
        BancoModel GetById(int bancoId);

    }
}
