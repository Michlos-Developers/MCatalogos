using DomainLayer.Models.TitulosPagar;

namespace ServiceLayer.Services.TitulosPagarServices
{
    public interface ITituloPagarServices
    {
        void ValidateModel(ITituloPagarModel tituloPagar);
    }
}
