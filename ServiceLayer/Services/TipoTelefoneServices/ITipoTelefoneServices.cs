using DomainLayer.Models.CommonModels.Enums;

namespace ServiceLayer.Services.TipoTelefoneServices
{
    public interface ITipoTelefoneServices
    {
        void ValidateModel(ITipoTelefoneModel tipoTelefoneModel);
    }
}
