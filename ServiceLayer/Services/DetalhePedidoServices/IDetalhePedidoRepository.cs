using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;

using System.Collections.Generic;

namespace ServiceLayer.Services.DetalhePedidoServices
{
    public interface IDetalhePedidoRepository
    {
        DetalhePedidoModel AddWithTamanho(IDetalhePedidoModel detalhePedidoModel);
        DetalhePedidoModel AddNoTamanho(IDetalhePedidoModel detalhePedidoModel);

        void Update(IDetalhePedidoModel detalhePedidoModel);
        void Delete(IDetalhePedidoModel detalhePedidoModel);

        DetalhePedidoModel GetById(int detalheId);
        IEnumerable<IDetalhePedidoModel> GetAll();
        IEnumerable<IDetalhePedidoModel> GetAllByPedido(IPedidosVendedorasModel pedidosVendedorasModel);
        IEnumerable<IDetalhePedidoModel> GetAllByPedidoCatalogo(IPedidosVendedorasModel pedidosVendedorasModel, ICatalogoModel catalogoModel);
        IEnumerable<IDetalhePedidoModel> GetAllByCampanha(ICampanhaModel model);
    }
}
