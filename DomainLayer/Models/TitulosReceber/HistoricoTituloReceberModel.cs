using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.TitulosReceber
{
    public class HistoricoTituloReceberModel : IHistoricoTituloReceberModel
    {
        [Key()]
        public int HistoricoId { get; set; }

        [Required()]
        [ForeignKey("TituloReceberModel")]
        public int TituloId { get; set; }
        public virtual TituloReceberModel TituloReceberModel { get; set; }

        [Required()]
        public DateTime DataRegistro { get; set; }

        [Required()]
        public double ValorRegistrado { get; set; }

        [Required()]
        public string Descricao { get; set; }


    }
}
