namespace DomainLayer.Models.Catalogos
{
    public interface ICatalogoModel
    {
        bool Ativo { get; set; }
        int CatalogoId { get; set; }
        int FornecedorId { get; set; }
        float MargemPadraoDistribuidor { get; set; }
        float MargemPadraoVendedora { get; set; }
        string Nome { get; set; }
    }
}