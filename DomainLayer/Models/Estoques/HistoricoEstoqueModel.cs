﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Estoques
{
    public class HistoricoEstoqueModel : IHistoricoEstoqueModel
    {
        [Key]
        public int HistoricoId { get; set; }

        [Required]
        public int EstoqueId { get; set; }

        public int Quantidade { get; set; }
        public float ValorCompra { get; set; }
        public float ValorSaida { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
