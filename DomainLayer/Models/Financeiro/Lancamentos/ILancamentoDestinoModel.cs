namespace DomainLayer.Models.Financeiro.Lancamentos
{
    public interface ILancamentoDestinoModel
    {
        string Destino { get; set; }
        int DestinoId { get; set; }
        LancamentoDestino LancamentoDestino { get; set; }
    }
}