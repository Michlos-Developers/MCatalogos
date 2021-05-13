namespace DomainLayer.Models.Vendedora
{
    public interface IRotaModel
    {
        int RotaId { get; set; }
        int Numero { get; set; }
        int RotaLetraId { get; set; }
        RotaLetraModel RotaLetra { get; set; }
        int VendedoraId { get; set; }
        VendedoraModel Vendedora { get; set; }
    }
}