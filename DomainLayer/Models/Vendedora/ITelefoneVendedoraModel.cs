namespace DomainLayer.Models.Vendedora
{
    public interface ITelefoneVendedoraModel
    {
        string Numero { get; set; }
        int TelefoneId { get; set; }
        TelefoneVendedoraModel.TipoTelefone Tipo { get; set; }
        VendedoraModel Vendedora { get; set; }
    }
}