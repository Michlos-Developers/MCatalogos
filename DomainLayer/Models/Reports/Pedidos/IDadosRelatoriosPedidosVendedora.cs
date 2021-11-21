using System;

namespace DomainLayer.Models.Reports.Pedidos
{
    public interface IDadosRelatoriosPedidosVendedora
    {
        string CatalogoNome { get; set; }
        DateTime DataVencimento { get; set; }
        string ItemDescricao { get; set; }
        int ItemQuantidade { get; set; }
        string ItemReferencia { get; set; }
        double ItemValorTotal { get; set; }
        double ItemValorUnitario { get; set; }
        int PedidoId { get; set; }
        string VendedoraNome { get; set; }
    }
}