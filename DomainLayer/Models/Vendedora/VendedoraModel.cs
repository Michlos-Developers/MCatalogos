using DomainLayer.Models.CommonModels.Address;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Vendedora
{
    public class VendedoraModel : IVendedoraModel
    {
        public int VendedoraId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é campo obrigatório")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Nome deve ter mais de 10 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O CPF é campo obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Utilize somente números")]
        public string Cpf { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O RG é campo obrigatório")]
        [MaxLength(20)]
        public string Rg { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Emissor do Documento é campo obrigatório")]
        [StringLength(20)]
        public string RgEmissor { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Data de Nascimento é campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [StringLength(300, MinimumLength = 5, ErrorMessage = "Nome do Pai deve ter mais de 10 caracteres")]
        public string NomePai { get; set; }

        [StringLength(300, MinimumLength = 5, ErrorMessage = "Nome da Mãe deve ter mais de 10 caracteres")]
        public string NomeMae { get; set; }

        [StringLength(300, MinimumLength = 5, ErrorMessage = "Nome do Conjuge deve ter mais de 10 caracteres")]
        public string NomeConjuge { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Deve informar o Endereço da Vendedora")]
        [StringLength(300, MinimumLength = 4, ErrorMessage = "O Logradouro deve ter mais de 5 caracteres")]
        public string Logradouro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o número da casa. Você pode utilizar S/N se não tiver número")]
        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(9)]
        public string Cep { get; set; }




        #region FOREIGNKEYS

        public virtual ObservableCollection<TelefoneVendedoraModel> Telefones { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int RotaLetraId { get; set; }
        public RotaLetraModel RotaLetra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a UF do Documento. É obrigatório")]
        public int UfRgId { get; set; }
        public EstadoModel UfRg { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "O Estado Civil deve ser informado.")]
        public int EstadoCivilId { get; set; }
        public EstadoCivilModel EstadoCivil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Selecione um Bairro")]
        public int BairroId { get; set; }
        public BairroModel Bairro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleciona uma Cidade")]
        public int CidadeId { get; set; }
        public CidadeModel Cidade { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Estado")]
        public int EstadoId { get; set; }
        public EstadoModel Estado { get; set; }
        
        #endregion


    }
}
