namespace DomainLayer.Models.CommonModels.Address
{
    public interface IBairroModel
    {
        int BairroId { get; set; }
        CidadeModel Cidade { get; set; }
        int CidadeId { get; set; }
        string Nome { get; set; }
    }
}