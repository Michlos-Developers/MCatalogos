using DomainLayer.Models.TitulosReceber;
using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.TitulosReceberServices
{
    public interface ITituloReceberRepository
    {
        ITituloReceberModel Add(ITituloReceberModel tituloReceber);

        void AbaterValor(ITituloReceberModel tituloReceber, double valorAbatido);

        void LiquidarTitulo(ITituloReceberModel tituloReceber);
        
        void Protestar(ITituloReceberModel tituloReceber);

        void Cancelar(ITituloReceberModel tituloReceber);

        IEnumerable<ITituloReceberModel> GetAll();

        IEnumerable<ITituloReceberModel> GetAllByVendedora(IVendedoraModel vendedoraModel);
        
        ITituloReceberModel GetById(int id);
    }
}
