using DomainLayer.Models.Modulos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ModulosServices
{
    public class ModulosSerivces : IModulosRepository
    {
        private IModulosRepository _modulosRepository;

        public ModulosSerivces(IModulosRepository modulosRepository)
        {
            _modulosRepository = modulosRepository;
        }

        public ModulosModel Disable(IModulosModel modulo)
        {
            return _modulosRepository.Disable(modulo);
        }

        public ModulosModel Enable(IModulosModel modulo)
        {
            return _modulosRepository.Enable(modulo);
        }

        public IEnumerable<IModulosModel> GetAll()
        {
            return _modulosRepository.GetAll();
        }
    }
}
