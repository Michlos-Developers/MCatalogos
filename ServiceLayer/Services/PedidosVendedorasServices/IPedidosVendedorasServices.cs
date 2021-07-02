using DomainLayer.Models.PedidosVendedoras;

namespace ServiceLayer.Services.PedidosVendedorasServices
{
    public interface IPedidosVendedorasServices
    {
        void ValidateModel(IPedidosVendedorasModel pedidosModel);
    }
}
