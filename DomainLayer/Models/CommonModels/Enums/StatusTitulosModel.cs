namespace DomainLayer.Models.CommonModels.Enums
{
    public class StatusTitulosModel : IStatusTitulosModel
    {
        public enum StatusTitulo
        {
            Aberto,
            Liquidado,
            Vencido,
            Cancelado,
            Protestado
        }

        public int StatusId { get; set; }
        public string Descricao { get; set; }

    }
}
