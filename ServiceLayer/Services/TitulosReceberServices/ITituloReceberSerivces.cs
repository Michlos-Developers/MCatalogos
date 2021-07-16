using DomainLayer.Models.TitulosReceber;

namespace ServiceLayer.Services.TitulosReceberServices
{
    public interface ITituloReceberSerivces
    {
        void ValidateModel(ITituloReceberModel tituloReceber);
    }
}
