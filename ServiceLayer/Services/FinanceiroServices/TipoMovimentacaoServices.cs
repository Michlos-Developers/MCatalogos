using DomainLayer.Models.Financeiro.Caixa.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FinanceiroServices
{
    public class TipoMovimentacaoServices: ITipoMovimentacaoRepository
    {
        private ITipoMovimentacaoRepository _tipoMovimentacaoRepository;

        public TipoMovimentacaoServices(ITipoMovimentacaoRepository tipoMovimentacaoRepository)
        {
            _tipoMovimentacaoRepository = tipoMovimentacaoRepository;
        }

        public IEnumerable<TipoMovimentacaoModel> GetAll()
        {
            return _tipoMovimentacaoRepository.GetAll();
        }

        public TipoMovimentacaoModel GetById(int tipoId)
        {
            return _tipoMovimentacaoRepository.GetById(tipoId);
        }

        public TipoMovimentacaoModel GetByTipo(string tipo)
        {
            return _tipoMovimentacaoRepository.GetByTipo(tipo);
        }

        public TipoMovimentacaoModel GetByTipoEnum(TipoMovimentacao tipo)
        {
            return _tipoMovimentacaoRepository.GetByTipoEnum(tipo);
        }
    }
}
