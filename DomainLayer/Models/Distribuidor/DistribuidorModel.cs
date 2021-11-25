using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Distribuidor
{
    public class DistribuidorModel : IDistribuidorModel
    {
        [Key]
        public int DistribuidorId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Nome Fantasia deve ter no mínimo 10 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Razão Social deve ter no mínimo 10 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter 14 caracteres")]
        [RegularExpression(@"[0-9]{14}", ErrorMessage = "Utilize somente números")]
        public string Cnpj { get; set; }

        [StringLength(14, MinimumLength = 9, ErrorMessage = "Inscrição Estadual deve ter no mínimo 8 caracteres")]
        [RegularExpression(@"[0-9]{14}", ErrorMessage = "Utilize somente números")]
        public string InscricaoEstadual { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(300)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [StringLength(300)]
        public string WebSite { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do Responsável pela empresa deve ser preenchido.")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Nome do Responsável deve ter no mínimo 10 caracteres")]
        public string NomeResponsavel { get; set; }

        public int DiaVencimento { get; set; }
        public int DiaEmissaoPromissoria { get; set; }

        public string TelefoneContato { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(300)]
        public string Logradouro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(300)]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        [StringLength(9)]
        public string Cep { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        public int UfId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        public int CidadeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório!")]
        public int BairroId { get; set; }


    }
}
