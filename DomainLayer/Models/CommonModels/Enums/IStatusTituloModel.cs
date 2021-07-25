namespace DomainLayer.Models.CommonModels.Enums
{
    public interface IStatusTituloModel
    {
        string Descricao { get; set; }
        StatusTitulo Status { get; set; }
        int StatusId { get; set; }
    }
}