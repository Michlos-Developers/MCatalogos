using DomainLayer.Models.Catalogos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CatalogoServices
{
    public interface ICampanhaServices
    {
        void ValidateModel(ICatalogoModel catalogoModel);
    }
}
