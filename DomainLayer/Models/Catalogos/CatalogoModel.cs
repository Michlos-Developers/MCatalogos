using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Catalogos
{
    public class CatalogoModel : ICatalogoModel, IDisposable
    {
        void IDisposable.Dispose() { }
        public void Dispose() { }
        public int CatalogoId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do Catálogo é campo obrigatório")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O Nome deve possuir entre 5 e 200 caracteres.")]
        public string Nome { get; set; }
        public float MargemPadraoVendedora { get; set; }
        public float MargemPadraoDistribuidor { get; set; }
        public bool Ativo { get; set; }
        public bool TaxaProduto { get; set; }
        public float ValorTaxaProduto { get; set; }
        public bool TaxaPedido { get; set; }
        public float ValorTaxaPedido { get; set; }
        [Required]
        public int FornecedorId { get; set; }

        public bool VariacaoDeValor { get; set; }
        public string TamanhoValorVariavel { get; set; }
        public string NumeracaoValorVariavel { get; set; }
        public bool ImportaProdutos { get; set; }



    }
}
