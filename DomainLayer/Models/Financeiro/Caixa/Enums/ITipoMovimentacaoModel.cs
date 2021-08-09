namespace DomainLayer.Models.Financeiro.Caixa.Enums
{
    public interface ITipoMovimentacaoModel
    {
        TipoMovimentacao Tipo { get; set; }
        int TipoId { get; set; }
        string TipoMovimentacao { get; set; }
    }
}