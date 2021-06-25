using DomainLayer.Models.Tamanho;

namespace ServiceLayer.Services.TamanhoServices
{
    public interface ITamanhoServices
    {
        void ValidateModel(ITamanhosModel tamanhosModel);
    }
}
