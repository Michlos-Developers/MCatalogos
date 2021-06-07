namespace DomainLayer.Models.Distribuidor
{
    public interface IDistribuidorModel
    {
        int BairroId { get; set; }
        string Cep { get; set; }
        int CidadeId { get; set; }
        string Cnpj { get; set; }
        string Complemento { get; set; }
        int DistribuidorId { get; set; }
        string Email { get; set; }
        string InscricaoEstadual { get; set; }
        string Logradouro { get; set; }
        string NomeFantasia { get; set; }
        string NomeResponsavel { get; set; }
        string Numero { get; set; }
        string RazaoSocial { get; set; }
        string TelefoneContato { get; set; }
        int UfId { get; set; }
        string WebSite { get; set; }
    }
}