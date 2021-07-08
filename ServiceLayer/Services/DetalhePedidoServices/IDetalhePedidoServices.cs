using DomainLayer.Models.PedidosVendedoras;

namespace ServiceLayer.Services.DetalhePedidoServices
{
    public interface IDetalhePedidoServices
    {
        void ValidateModel(IDetalhePedidoModel detalhePedidoModel);
    }
}
