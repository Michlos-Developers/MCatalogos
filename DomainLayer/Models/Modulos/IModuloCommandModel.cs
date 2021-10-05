namespace DomainLayer.Models.Modulos
{
    public interface IModuloCommandModel
    {
        string Command { get; set; }
        int CommandId { get; set; }
        string CommandName { get; set; }
        int ModuloId { get; set; }
        ModulosModel ModulosModel { get; set; }
    }
}