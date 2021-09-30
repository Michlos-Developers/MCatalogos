namespace DomainLayer.Models.Financeiro.Banco
{
    public interface IContaModel
    {
        int BancoId { get; set; }
        BancoModel BancoModel { get; set; }
        bool Cancelado { get; set; }
        int ContaId { get; set; }
        string DvNumeroAgencia { get; set; }
        string DvNumeroConta { get; set; }
        string NumeroAgencia { get; set; }
        string NumeroConta { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoAtual { get; set; }
    }
}