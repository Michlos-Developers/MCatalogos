using DomainLayer.Models.CommonModels.Enums;

using System.Collections.Generic;

namespace ServiceLayer.Services.TipoTituloServices
{
    public interface ITipoTituloRepository
    {
        IEnumerable<ITipoTituloModel> GetAll();
        TipoTituloModel GetByTipo(string tipoTitulo);
        TipoTituloModel GetById(int tipoTituloId);
    }
}
