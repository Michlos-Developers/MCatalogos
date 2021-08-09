namespace DomainLayer.Models.Financeiro.Caixa.Enums
{
    public class TipoMovimentacaoModel : ITipoMovimentacaoModel
    {
        public int TipoId { get; set; }
        public string TipoMovimentacao { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }
}
