using System;

namespace DomainLayer.Models.Catalogos
{
    public interface ICampanhaModel
    {
        bool Ativa { get; set; }
        int CampanhaId { get; set; }
        DateTime DataEncerramento { get; set; }
        DateTime DataLancamento { get; set; }
        string Nome { get; set; }
        int CatalogoId { get; set; }
    }
}