using DomainLayer.Models.CommonModels.Enums;

using System.Collections.Generic;

namespace ServiceLayer.CommonServices
{
    public interface IStatusTitulosRepository
    {
        IEnumerable<StatusTituloModel> GetAll();
        StatusTituloModel GetByStatus(string status);
        StatusTituloModel GetById(int statusId);
        StatusTituloModel GetByStatusEnum(StatusTitulo status);
    }
}
