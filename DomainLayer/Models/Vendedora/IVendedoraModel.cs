using DomainLayer.Models.CommonModels.Address;

using System;
using System.Collections.ObjectModel;

namespace DomainLayer.Models.Vendedora
{
    public interface IVendedoraModel
    {
        BairroModel Bairro { get; set; }
        int BairroId { get; set; }
        string Cep { get; set; }
        CidadeModel Cidade { get; set; }
        int CidadeId { get; set; }
        string Complemento { get; set; }
        string Cpf { get; set; }
        DateTime DataNascimento { get; set; }
        string Email { get; set; }
        EstadoModel Estado { get; set; }
        EstadoCivilModel EstadoCivil { get; set; }
        int EstadoCivilId { get; set; }
        int EstadoId { get; set; }
        string Logradouro { get; set; }
        string Nome { get; set; }
        string NomeConjuge { get; set; }
        string NomeMae { get; set; }
        string NomePai { get; set; }
        string Numero { get; set; }
        string Rg { get; set; }
        string RgEmissor { get; set; }
        ObservableCollection<TelefoneVendedoraModel> Telefones { get; set; }
        EstadoModel UfRg { get; set; }
        int UfRgId { get; set; }
        int RotaLetraId { get; set; }
        RotaLetraModel RotaLetra { get; set; }
        int VendedoraId { get; set; }
    }
}