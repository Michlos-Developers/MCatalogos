using DomainLayer.Models.CommonModels.Enums;

using System.Collections.Generic;

namespace ServiceLayer.CommonServices
{
    public interface IStatusTitulosRepository
    {
        IEnumerable<IStatusTitulosModel> GetAll();
        StatusTitulosModel GetByStatus(string status);
        StatusTitulosModel GetById(int statusId);
        StatusTitulosModel.StatusTitulo GetByStatusEnum(StatusTitulosModel.StatusTitulo status);
    }
}
