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


        public void AtualizaTotaisPedido(IPedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.AtualizaTotaisPedido(pedido); 
        }


        public void ValidateModel(IPedidosVendedorasModel pedidosModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(pedidosModel);
        }

        public void SetStatus(int status, PedidosVendedorasModel pedido)
        {
            _pedidosVendedorasRepository.SetStatus(status, pedido);
        }
    }
}
