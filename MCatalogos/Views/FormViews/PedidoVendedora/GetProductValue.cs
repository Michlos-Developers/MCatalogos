using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using System;

namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    public class GetProductValue
    {
        /// <summary>
        /// RETORNA O VALOR DO PRODUTO REFERENTE AO TAMANHO DO PRODUTO.
        /// </summary>
        /// <param name="produtoModel"></param>
        /// <param name="tamanhoModel"></param>
        /// <returns></returns>
        public double VerificaValorProduto(ProdutoModel produtoModel, TamanhosModel tamanhoModel)
        {
            double productValue;

            if (tamanhoModel != null)
            {
                int tamanhos = ((int)(Tamanhos)Enum.Parse(typeof(Tamanhos), tamanhoModel.Tamanho));
                if (tamanhos >= ((int)Tamanhos.GG))
                {
                    productValue = produtoModel.ValorCatalogo2 != 0 ? produtoModel.ValorCatalogo2 : produtoModel.ValorCatalogo;
                }
                else
                {
                    productValue = produtoModel.ValorCatalogo;
                }

                
            }
            else
            {
                productValue = produtoModel.ValorCatalogo;
            }

            return productValue;
        }
    }
}
