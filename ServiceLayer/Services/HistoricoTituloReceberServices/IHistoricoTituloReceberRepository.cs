using DomainLayer.Models.TitulosReceber;

using System.Collections.Generic;

namespace ServiceLayer.Services.HistoricoTituloReceberServices
{
    public interface IHistoricoTituloReceberRepository
    {
        IHistoricoTituloReceberModel Add(IHistoricoTituloReceberModel historico);

        IEnumerable<IHistoricoTituloReceberModel> GetAllByTitulo(ITituloReceberModel titulo);

        IHistoricoTituloReceberModel GetById(int historicoId);

    }
}
