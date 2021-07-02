using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.PedidosVendedorasServices
{
    public class PedidosVendedorasServices : IPedidosVendedorasServices, IPedidosVendedorasRepository
    {
        private IPedidosVendedorasRepository _pedidosVendedorasRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public PedidosVendedorasServices(IPedidosVendedorasRepository pedidosVendedorasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _pedidosVendedorasRepository = pedidosVendedorasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IPedidosVendedorasModel Add(IPedidosVendedorasModel pedido)
        {
            return _pedidosVendedorasRepository.Add(pedido);
        }

        public void Cancelar(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Cancelar(pedido);
        }

        public void Conferir(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Conferir(pedido);
        }

        public void Despachar(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Despachar(pedido);
        }

        public void Entregar(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Entregar(pedido);
        }

        public void Enviar(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Enviar(pedido);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAll()
        {
            return _pedidosVendedorasRepository.GetAll();
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataConferenciaIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataConferenciaIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataDespachoIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataDespachoIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataEntregaIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataEntregaIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataEnvioIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataEnvioIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataRegistroIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataRegistroIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataSeparadoIniFim(DateTime dataIni, DateTime dataFim)
        {
            return _pedidosVendedorasRepository.GetAllByDataSeparadoIniFim(dataIni, dataFim);
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByVendedora(IVendedoraModel vendedora)
        {
            return _pedidosVendedorasRepository.GetAllByVendedora(vendedora);
        }

        public IPedidosVendedorasModel GetById(int pedidoId)
        {
            return _pedidosVendedorasRepository.GetById(pedidoId);
        }

        public IPedidosVendedorasModel GetByVendedoraMes(IVendedoraModel vendedora, DateTime dataMes)
        {
            return _pedidosVendedorasRepository.GetByVendedoraMes(vendedora, dataMes);
        }

        public void Separar(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.Separar(pedido);
        }

        public void SomarLucroDistribuidor(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.SomarLucroDistribuidor(pedido);
        }

        public void SomarLucroVendedora(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.SomarLucroVendedora(pedido);
        }

        public void SomarTotalPedido(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.SomarTotalPedido(pedido); 
        }


        public void ValidateModel(IPedidosVendedorasModel pedidosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(pedidosModel);
        }
    }
}
