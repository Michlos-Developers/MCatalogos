using System;

namespace DomainLayer.Models.Modulos
{
    public class ModulosModel : IModulosModel
    {
        public int ModuloId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtivacao { get; set; }

    }
}
