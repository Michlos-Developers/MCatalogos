using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TelefoneVendedoraServices
{
    public interface ITelefoneVendedoraServices
    {
        void ValidateMode(ITelefoneVendedoraModel telefoneVendedoraModel);
    }
}
