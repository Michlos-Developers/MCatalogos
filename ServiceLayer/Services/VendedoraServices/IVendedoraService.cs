using DomainLayer.Models.Vendedora;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraService
    {
        /// <summary>
        /// CONTRATO DE VALIDAÇÃO DE DADOS DA VENDEDORA
        /// </summary>
        /// <param name="vendedoraModel"></param>
        void ValidateModel(IVendedoraModel vendedoraModel);
    }
}
