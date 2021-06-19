using System;

namespace DomainLayer.Models.Estoques
{
    public interface IHistoricoEstoqueModel
    {
        DateTime DataRegistro { get; set; }
        int EstoqueId { get; set; }
        int HistoricoId { get; set; }
        int Quantidade { get; set; }
        float ValorCompra { get; set; }
        float ValorSaida { get; set; }
    }
}