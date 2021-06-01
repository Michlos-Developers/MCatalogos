using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraRepository
    {
        VendedoraModel Add(IVendedoraModel vendedoraModel);
        void Update(IVendedoraModel vendedoraModel);
        void Delete(IVendedoraModel vendedoraModel);
        IEnumerable<IVendedoraModel> GetAll();
        VendedoraModel GetById(int id);
        VendedoraModel GetByCpf(string cpf);
    }
}
