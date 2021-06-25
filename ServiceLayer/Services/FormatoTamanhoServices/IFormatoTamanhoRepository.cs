using DomainLayer.Models.Formatos;

using System.Collections.Generic;

namespace ServiceLayer.Services.FormatoTamanhoServices
{
    public interface IFormatoTamanhoRepository
    {
        FormatosTamanhosModel Add(IFormatosTamanhosModel formatosTamanhosModel);
        void Update(IFormatosTamanhosModel formatosTamanhosModel);
        void Delete(IFormatosTamanhosModel formatosTamanhosModel);
        IEnumerable<FormatosTamanhosModel> GetAll();
        FormatosTamanhosModel GetById(int formatoId);
    }
}
