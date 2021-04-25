using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CommonModels.Address
{
    public class BairroModel : IBairroModel
    {
        public int BairroId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome do Bairro é obrigatório")]
        [StringLength(300 , MinimumLength = 3, ErrorMessage = "O nome do bairro deve conter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "A Cidade deve ser informada")]
        public int CidadeId { get; set; }
        public CidadeModel Cidade { get; set; }
    }
}
