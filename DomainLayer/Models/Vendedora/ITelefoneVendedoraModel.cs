using DomainLayer.Models.CommonModels.Enums;

namespace DomainLayer.Models.Vendedora
{
    public interface ITelefoneVendedoraModel
    {
        string Numero { get; set; }
        int TelefoneId { get; set; }
        TipoTelefoneModel TipoTelefone { get; set; }
        int TipoTelefoneId { get; set; }
        VendedoraModel Vendedora { get; set; }
        int VendedoraId { get; set; }
    }
}