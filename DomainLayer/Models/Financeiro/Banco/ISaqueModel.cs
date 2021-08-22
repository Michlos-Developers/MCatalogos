using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;

using System;

namespace DomainLayer.Models.Financeiro.Banco
{
    public interface ISaqueModel
    {
        int BancoId { get; set; }
        BancoModel BancoModel { get; set; }
        int ProvisionamentoId { get; set; }
        ProvisionamentoModel ProvisionamentoModel { get; set; }
        int SaqueId { get; set; }
        TipoMovimentacao TipoMovimentacao { get; set; }
        double ValorSaque { get; set; }
        bool Cancelado { get; set; }
        DateTime DataRegistro { get; set; }
    }
}