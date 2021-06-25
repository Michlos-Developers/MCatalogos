using DomainLayer.Models.Formatos;

namespace ServiceLayer.Services.FormatoTamanhoServices
{
    public interface IFormatoTamanhoServices
    {
        void ValidateModel(IFormatosTamanhosModel formatosTamanhosModel);
    }
}
