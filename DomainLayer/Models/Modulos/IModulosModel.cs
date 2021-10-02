using System;

namespace DomainLayer.Models.Modulos
{
    public interface IModulosModel
    {
        bool Ativo { get; set; }
        DateTime DataAtivacao { get; set; }
        int ModuloId { get; set; }
        string Nome { get; set; }
    }
}