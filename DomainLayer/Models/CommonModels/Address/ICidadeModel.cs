namespace DomainLayer.Models.CommonModels.Address
{
    public interface ICidadeModel
    {
        int CidadeId { get; set; }
        string CodIbge { get; set; }
        EstadoModel Estado { get; set; }
        int EstadoId { get; set; }
        string Nome { get; set; }
        string Uf { get; set; }
    }
}