using DomainLayer.Models.CommonModels.Address;

namespace DomainLayer.Models.Fornecedores
{
    public interface IFornecedorModel
    {
        BairroModel Bairro { get; set; }
        int BairroId { get; set; }
        string Cep { get; set; }
        CidadeModel Cidade { get; set; }
        int CidadeId { get; set; }
        string Cnpj { get; set; }
        string ContatoPrincipal { get; set; }
        string Email { get; set; }
        int FornecedorId { get; set; }
        string InscricaoEstadual { get; set; }
        string Logradouro { get; set; }
        string NomeFantasia { get; set; }
        string Numero { get; set; }
        string RazaoSocial { get; set; }
        string WebSite { get; set; }
        EstadoModel Uf { get; set; }
        int UfId { get; set; }
    }
}