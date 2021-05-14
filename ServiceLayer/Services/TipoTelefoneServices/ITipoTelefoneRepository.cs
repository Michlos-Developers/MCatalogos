using DomainLayer.Models.CommonModels.Enums;

using System.Collections.Generic;

namespace ServiceLayer.Services.TipoTelefoneServices
{
    public interface ITipoTelefoneRepository
    {
        IEnumerable<ITipoTelefoneModel> GetAll();
        TipoTelefoneModel GetByTipo(string tipoTelefone);
        TipoTelefoneModel GetById(int tipoTelefoneId);
    }
}
