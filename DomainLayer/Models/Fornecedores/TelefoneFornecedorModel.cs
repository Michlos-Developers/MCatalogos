using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Fornecedores
{
    public class TelefoneFornecedorModel : ITelefoneFornecedorModel
    {
        public int TelefoneId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CampoObrigatório")]
        [StringLength(11)]
        public string Numero { get; set; }

        [StringLength(4)]
        public string Ramal { get; set; }

        [StringLength(200)]
        public string Contato { get; set; }

        [StringLength(200)]
        public string Departamento { get; set; }

        public int TipoTelefoneId { get; set; }
        public int FornecedorId { get; set; }

    }
}
