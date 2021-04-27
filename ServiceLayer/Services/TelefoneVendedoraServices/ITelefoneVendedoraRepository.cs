using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TelefoneVendedoraServices
{
    public interface ITelefoneVendedoraRepository
    {
        void Add(ITelefoneVendedoraModel telefoneVendedoraModel);
        void Update(ITelefoneVendedoraModel telefoneVendedoraModel);
        void Delete(ITelefoneVendedoraModel telefoneVendedoraModel);
        IEnumerable<ITelefoneVendedoraModel> GetAll();
        IEnumerable<ITelefoneVendedoraModel> GetByVendedoraId(int vendedoraId);
        TelefoneVendedoraModel GetById(int id);

    }
}
