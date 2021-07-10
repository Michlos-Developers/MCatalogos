using DomainLayer.Models.Catalogos;
using DomainLayer.Models.PedidosVendedoras;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DetalhePedidoServices
{
    public class DetalhePedidoSerivces : IDetalhePedidoServices, IDetalhePedidoRepository
    {
        private IDetalhePedidoRepository _detalhePedidoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DetalhePedidoSerivces(IDetalhePedidoRepository detalhePedidoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _detalhePedidoRepository = detalhePedidoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public DetalhePedidoModel AddNoTamanho(IDetalhePedidoModel detalhePedidoModel)
        {
            return _detalhePedidoRepository.AddNoTamanho(detalhePedidoModel);
        }

        public DetalhePedidoModel AddWithTamanho(IDetalhePedidoModel detalhePedidoModel)
        {
            return _detalhePedidoRepository.AddWithTamanho(detalhePedidoModel);
        }

        public void Delete(IDetalhePedidoModel detalhePedidoModel)
        {
            _detalhePedidoRepository.Delete(detalhePedidoModel);
        }

        public IEnumerable<IDetalhePedidoModel> GetAll()
        {
            return _detalhePedidoRepository.GetAll();
        }

        public IEnumerable<IDetalhePedidoModel> GetAllByPedido(IPedidosVendedorasModel pedidosVendedorasModel)
        {
            return _detalhePedidoRepository.GetAllByPedido(pedidosVendedorasModel);
        }

        public IEnumerable<IDetalhePedidoModel> GetAllByPedidoCatalogo(IPedidosVendedorasModel pedidosVendedorasModel, ICatalogoModel catalogoModel)
        {
            return _detalhePedidoRepository.GetAllByPedidoCatalogo(pedidosVendedorasModel, catalogoModel);
        }

        public DetalhePedidoModel GetById(int detalheId)
        {
            return _detalhePedidoRepository.GetById(detalheId);
        }

        public void Update(IDetalhePedidoModel detalhePedidoModel)
        {
            _detalhePedidoRepository.Update(detalhePedidoModel);
        }

        public void ValidateModel(IDetalhePedidoModel detalhePedidoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(detalhePedidoModel);
        }
    }
}
