namespace DomainLayer.Models.Vendedora
{
    public interface IRotaModel
    {
        string Letra { get; set; }
        string Numero { get; set; }
        int RotaId { get; set; }
    }
}