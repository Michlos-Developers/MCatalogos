using DomainLayer.Models.Catalogos;

namespace ServiceLayer.Services.CatalogoServices
{
    public interface ICatalogoServices
    {
        void ValidateMOdel(ICatalogoModel catalogoModel);
    }
}
