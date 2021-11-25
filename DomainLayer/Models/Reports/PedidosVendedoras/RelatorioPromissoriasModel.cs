using System;

namespace DomainLayer.Models.Reports.PedidosVendedoras
{
    public class RelatorioPromissoriasModel : IRelatorioPromissoriasModel
    {
        public int PedidoId { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorPagar { get; set; }
        public DateTime DataVencimento { get; set; }

        public int VendedoraId { get; set; }
        public string VendedoraNome { get; set; }
        public string VendedoraCpf { get; set; }
        public string VendedoraEndereco { get; set; }

        public string DistribuidorCidade { get; set; }
        public string DistribuidorRazao { get; set; }
        public string DistribuidorCnpj { get; set; }

        public string ExtensoValor { get; set; }
        public string ExtensoDataVencimento { get; set; }
    }
}
