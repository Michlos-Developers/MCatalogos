using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Tests
{
    public class VendedoraServicesFixture
    {
        private IVendedoraService _vendedoraServices;
        private IVendedoraModel _vendedoraModel;

        public VendedoraServicesFixture()
        {
            _vendedoraModel = new VendedoraModel();
            _vendedoraServices = new VendedoraServices(null, new ModelDataAnnotationCheck());
        }

        public VendedoraModel VendedoraModel
        {
            get { return (VendedoraModel)_vendedoraModel; }
            set { _vendedoraModel = value; }
        }


        public VendedoraServices VendedoraServices
        {
            get { return (VendedoraServices)_vendedoraServices; }
            set { _vendedoraServices = value; }
        }

    }
}
