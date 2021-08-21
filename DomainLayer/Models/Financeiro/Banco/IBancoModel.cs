namespace DomainLayer.Models.Financeiro.Banco
{
    public interface IBancoModel
    {
        int BancoId { get; set; }
        string DvNumeroAgencia { get; set; }
        string DvNumeroConta { get; set; }
        string NomeBanco { get; set; }
        string NumeroAgencia { get; set; }
        int NumeroBanco { get; set; }
        string NumeroConta { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoAtual { get; set; }
        bool Cancelado { get; set; }
    }
}