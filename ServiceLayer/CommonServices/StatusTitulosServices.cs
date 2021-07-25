using DomainLayer.Models.CommonModels.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonServices
{
    public class StatusTitulosServices : IStatusTitulosRepository
    {
        private IStatusTitulosRepository _statusTitulosRepository;

        public StatusTitulosServices(IStatusTitulosRepository statusTitulosRepository)
        {
            _statusTitulosRepository = statusTitulosRepository;
        }

        public IEnumerable<StatusTituloModel> GetAll()
        {
            return _statusTitulosRepository.GetAll();
        }

        public StatusTituloModel GetById(int statusId)
        {
            return _statusTitulosRepository.GetById(statusId);
        }

        public StatusTituloModel GetByStatus(string status)
        {
            return _statusTitulosRepository.GetByStatus(status);
        }

        public StatusTituloModel GetByStatusEnum(StatusTitulo status)
        {
            return _statusTitulosRepository.GetByStatusEnum(status);
        }
    }
}
