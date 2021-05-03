namespace DomainLayer.Models.Vendedora
{
    public interface IRotaModel
    {
        string Letra { get; set; }
        int Numero { get; set; }
        int RotaId { get; set; }
    }
}