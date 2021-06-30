namespace DomainLayer.Models.Catalogos
{
    public interface ICatalogoModel
    {
        bool TaxaProduto { get; set; }
        bool TaxaPedido { get; set; }
        bool Ativo { get; set; }
        int CatalogoId { get; set; }
        int FornecedorId { get; set; }
        float ValorTaxaProduto { get; set; }
        float ValorTaxaPedido { get; set; }
        float MargemPadraoDistribuidor { get; set; }
        float MargemPadraoVendedora { get; set; }
        string Nome { get; set; }
        bool VariacaoDeValor { get; set; }
        string TamanhoValorVariavel { get; set; }
        string NumeracaoValorVariavel { get; set; }
    }
}