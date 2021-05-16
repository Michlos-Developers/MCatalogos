namespace DomainLayer.Models.Fornecedores
{
    public interface ITelefoneFornecedorModel
    {
        string Contato { get; set; }
        string Departamento { get; set; }
        int FornecedorId { get; set; }
        string Numero { get; set; }
        string Ramal { get; set; }
        int TelefoneId { get; set; }
        int TipoTelefoneId { get; set; }
    }
}