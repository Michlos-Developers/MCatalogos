using DomainLayer.Models.Modulos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ModulosServices
{
    public class ModuloCommandServices : IModuloCommandRepository
    {
        private IModuloCommandRepository _commandRepository;

        public ModuloCommandServices(IModuloCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public IEnumerable<IModuloCommandModel> GetAll()
        {
            return _commandRepository.GetAll();
        }

        public IEnumerable<IModuloCommandModel> GetAllByModuloId(int moduloId)
        {
            return _commandRepository.GetAllByModuloId(moduloId);
        }
    }
}
