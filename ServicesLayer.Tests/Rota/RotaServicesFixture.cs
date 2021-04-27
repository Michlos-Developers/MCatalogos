using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.RotaServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Tests
{
    public class RotaServicesFixture
    {
        private IRotaServices _rotaServices;
        private IRotaModel _rotaModel;

        public RotaServicesFixture()
        {
            _rotaModel = new RotaModel();
            _rotaServices = new RotaServices(null, new ModelDataAnnotationCheck());
        }

        public RotaModel RotaModel
        {
            get { return (RotaModel)_rotaModel; }
            set { _rotaModel = value; }
        }

        public RotaServices RotaServices
        {
            get { return (RotaServices)_rotaServices; }
            set { _rotaServices = value; }
        }

    }
}
