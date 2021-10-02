using DomainLayer.Models.Modulos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ModulosServices
{
    public interface IModulosRepository
    {
        ModulosModel Enable(IModulosModel modulo);
        ModulosModel Disable(IModulosModel modulo);
        IEnumerable<IModulosModel> GetAll();
        
    }
}
