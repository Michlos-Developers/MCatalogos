namespace DomainLayer.Models.Financeiro.Lancamentos
{
    public class LancamentoDestinoModel : ILancamentoDestinoModel
    {
        public int DestinoId { get; set; }
        public string Destino { get; set; }
        public LancamentoDestino LancamentoDestino { get; set; }
    }
}
