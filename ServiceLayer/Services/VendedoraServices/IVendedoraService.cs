﻿using DomainLayer.Models.Vendedora;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraService
    {
        void ValidateModel(IVendedoraModel vendedoraModel);
    }
}
