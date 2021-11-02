using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.PedidosVendedoras
{
    public class DetalhePedidoModel : IDetalhePedidoModel
    {
        [Key()]
        public int DetalheId { get; set; }


        [Required()]
        [ForeignKey("PedidosVendedorasModel")]
        public int PedidoId { get; set; }
        public virtual PedidosVendedorasModel PedidosVendedorasModel { get; set; }


        [Required()]
        [ForeignKey("CatalogoModel")]
        public int CatalogoId { get; set; }
        public virtual CatalogoModel CatalogoModel { get; set; }


        [Required()]
        [ForeignKey("CampanhaModel")]
        public int CampanhaId { get; set; }
        public virtual CampanhaModel CampanhaModel { get; set; }


        [Required()]
        [ForeignKey("ProdutoModel")]
        public int ProdutoId { get; set; }
        public virtual ProdutoModel ProdutoModel { get; set; }

        [Required()]
        public string Referencia { get; set; }

        [Required()]
        public double MargemVendedora { get; set; }

        [Required()]
        public double MargemDistribuidor { get; set; }

        [Required()]
        public double ValorProduto { get; set; }

        [Required()]
        public int Quantidade { get; set; }

        public int TamanhoId { get; set; }
        public double ValorTaxaItem { get; set; }

        public double ValorTotalItem
        {
            get
            {
                return ValorProduto * Quantidade;
            }
        }

        public double ValorLucroVendedoraItem
        {
            get
            {
                return (((ValorProduto * (MargemVendedora / 100)) * Quantidade) - ValorTaxaItem);
            }
        }
        public double ValorLucroDistribuidorItem
        {
            get
            {
                return (((ValorProduto * (MargemDistribuidor / 100)) * Quantidade) - ValorLucroVendedoraItem);
            }
        }
        public double ValorPagarFornecedorItem
        {
            get
            {
                return (ValorTotalItem - ValorLucroDistribuidorItem - ValorLucroVendedoraItem);
            }
        }
        public bool Faltou { get; set; }


    }
}
