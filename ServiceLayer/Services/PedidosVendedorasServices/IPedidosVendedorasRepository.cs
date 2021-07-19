using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.PedidosVendedorasServices
{
    public interface IPedidosVendedorasRepository
    {
        IPedidosVendedorasModel Add(IPedidosVendedorasModel pedido);
        void AtualizaTotaisPedido(IPedidosVendedorasModel pedido);
        
        IPedidosVendedorasModel GetById(int pedidoId);
        IPedidosVendedorasModel GetByVendedoraMes(IVendedoraModel vendedora, DateTime dataMes);
        IEnumerable<IPedidosVendedorasModel> GetAll();
        IEnumerable<IPedidosVendedorasModel> GetAllByVendedora(IVendedoraModel vendedora);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataRegistroIniFim(DateTime dataIni, DateTime dataFim);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataEnvioIniFim(DateTime dataIni, DateTime dataFim);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataSeparadoIniFim(DateTime dataIni, DateTime dataFim);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataConferenciaIniFim(DateTime dataIni, DateTime dataFim);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataDespachoIniFim(DateTime dataIni, DateTime dataFim);
        IEnumerable<IPedidosVendedorasModel> GetAllByDataEntregaIniFim(DateTime dataIni, DateTime dataFim);
        void SetStatus(int status, PedidosVendedorasModel pedido);
        
    }
}
