namespace DomainLayer.Models.CommonModels.Enums
{
    public class StatusTituloModel : IStatusTituloModel
    {
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public StatusTitulo Status { get; set; }
    }
}
