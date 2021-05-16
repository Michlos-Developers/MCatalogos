using DomainLayer.Models.Vendedora;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraService
    {
        void ValidateModel(IVendedoraModel vendedoraModel);
    }
}
