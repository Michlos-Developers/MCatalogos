using System;

namespace DomainLayer.Models.TitulosReceber
{
    public interface IHistoricoTituloReceberModel
    {
        DateTime DataRegistro { get; set; }
        string Descricao { get; set; }
        int HistoricoId { get; set; }
        int TituloId { get; set; }
        TituloReceberModel TituloReceberModel { get; set; }
        double ValorRegistrado { get; set; }
    }
}