using System;

namespace DomainLayer.Models.Reports.Pedidos
{
    public class DadosRelatoriosPedidosVendedora : IDadosRelatoriosPedidosVendedora
    {
        public int PedidoId { get; set; }
        public string VendedoraNome { get; set; }
        public string CatalogoNome { get; set; }
        public DateTime DataVencimento { get; set; }
        public string ItemReferencia { get; set; }
        public string ItemDescricao { get; set; }
        public int ItemQuantidade { get; set; }
        public double ItemValorUnitario { get; set; }
        public double ItemValorTotal { get; set; }

    }
}
