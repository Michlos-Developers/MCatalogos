using DomainLayer.Models.Financeiro.Caixa.Enums;

using System.Collections.Generic;

namespace ServiceLayer.Services.FinanceiroServices
{
    public interface ITipoMovimentacaoRepository
    {
        IEnumerable<TipoMovimentacaoModel> GetAll();
        TipoMovimentacaoModel GetByTipo(string tipo);
        TipoMovimentacaoModel GetById(int tipoId);
        TipoMovimentacaoModel GetByTipoEnum(TipoMovimentacao tipo);
    }
}
