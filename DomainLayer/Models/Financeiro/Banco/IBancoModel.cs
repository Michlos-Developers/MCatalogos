namespace DomainLayer.Models.Financeiro.Banco
{
    public interface IBancoModel
    {
        int BancoId { get; set; }
        string NomeBanco { get; set; }
        int NumeroBanco { get; set; }
    }
}