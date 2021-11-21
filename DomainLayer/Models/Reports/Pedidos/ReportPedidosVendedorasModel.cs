using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Distribuidor;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Reports.Pedidos
{
    public class ReportPedidosVendedorasModel : IReportPedidosVendedorasModel
    {
        //public int ReportPedidoVendedoraId { get; set; }
        public int DistribuidorId { get; set; }
        public string DistribuidorNome { get; set; }

        public int VendedoraId { get; set; }
        public string VendedoraNome { get; set; }
        public int RotaLetraIdVendedora { get; set; }
        public string RotaLetraVendedora { get; set; }
        public int  RotaNumeroIdVendedora { get; set; }
        public string RotaNumeroVendedora { get; set; }


        public int CatalogoId { get; set; }
        public string CatalogoNome { get; set; }


        public int CampanhaId { get; set; }
        public string NomeCampanha { get; set; }

        public int PedidoId { get; set; }
        public double PedidoValorTotal { get; set; }
        public double PedidoValorLucroVendedora { get; set; }
        public double PedidoValorTotalPagar { get; set; }
        public DateTime DataRegistroPedido { get; set; }
        public DateTime DataVencimento { get; set; }





        public int DetlhePedidoId { get; set; }
        public int DetalheProdutoId { get; set; }
        public string DetalheProdutoReferencia { get; set; }
        public string DetalheProdutoDescricao { get; set; }
        public double DetalheProdutoValor { get; set; }
        public double DetalheMargemVendedora { get; set; }
        public int DetalheQuantidade { get; set; }
        public double DetalheValorTotalItem { get; set; }
        public double DetalheValorTotalBruto { get; set; } //VALOR A PAGAR
        public double DetalheValorTotalLiquido { get; set; } //VALOR DO LUCRO DA VENDEDORA 
        public bool DetalheFalta { get; set; }




    }
}

