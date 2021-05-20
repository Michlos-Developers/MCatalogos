using System;

namespace DomainLayer.Models.Catalogos
{
    public class CampanhaModel : ICampanhaModel
    {
        public int CampanhaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataEncerramento { get; set; }
        public bool Ativa { get; set; }
        public int CatalogoId { get; set; }


    }
}
