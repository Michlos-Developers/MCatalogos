using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraRepository
    {
        VendedoraModel Add(IVendedoraModel vendedoraModel);
        void Update(IVendedoraModel vendedoraModel);
        void Delete(IVendedoraModel vendedoraModel);
        IEnumerable<IVendedoraModel> GetAll();
        VendedoraModel GetById(int id);
    }
}
