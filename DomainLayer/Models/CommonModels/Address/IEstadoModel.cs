namespace DomainLayer.Models.CommonModels.Address
{
    public interface IEstadoModel
    {
        string CodIbge { get; set; }
        int EstadoId { get; set; }
        string Nome { get; set; }
        string Uf { get; set; }
    }
}