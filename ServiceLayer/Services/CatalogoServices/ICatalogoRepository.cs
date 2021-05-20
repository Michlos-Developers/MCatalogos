using DomainLayer.Models.Catalogos;

using System.Collections.Generic;

namespace ServiceLayer.Services.CatalogoServices
{
    public interface ICatalogoRepository
    {
        CatalogoModel Add(ICatalogoModel catalogoModel);
        void Update(ICatalogoModel catalogoModel);
        void Delete(ICatalogoModel catalogoModel);
        IEnumerable<ICatalogoModel> GetAll();
        IEnumerable<ICatalogoModel> GetByFornecedorId(int fornecedorId);
        CatalogoModel GetById(int id);

    }
}
