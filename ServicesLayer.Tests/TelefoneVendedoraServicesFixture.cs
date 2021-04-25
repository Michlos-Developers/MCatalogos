using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TelefoneVendedoraServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Tests
{
    public class TelefoneVendedoraServicesFixture
    {

        private ITelefoneVendedoraServices _telefoneVendedoraServices;
        private ITelefoneVendedoraModel _telefoneVendedoraModel;

        public TelefoneVendedoraServicesFixture()
        {
            _telefoneVendedoraModel = new TelefoneVendedoraModel();
            _telefoneVendedoraServices = new TelefoneVendedoraServices(null, new ModelDataAnnotationCheck());
        }

        public TelefoneVendedoraModel TelefoneVendedoraModel
        {
            get { return (TelefoneVendedoraModel)_telefoneVendedoraModel; }
            set { _telefoneVendedoraModel = value; }
        }

        public TelefoneVendedoraServices TelefoneVendedoraServices
        {
            get { return (TelefoneVendedoraServices)_telefoneVendedoraServices; }
            set { _telefoneVendedoraServices = value; }
        }
    }
}
