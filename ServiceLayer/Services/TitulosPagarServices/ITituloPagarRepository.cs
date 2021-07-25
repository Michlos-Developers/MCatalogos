using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.TitulosPagar;

using System.Collections.Generic;

namespace ServiceLayer.Services.TitulosPagarServices
{
    public interface ITituloPagarRepository
    {
        TituloPagarModel Add(ITituloPagarModel tituloPagar);
        void Liquidar(ITituloPagarModel tituloPagar);
        void AdicionarValorAdicional(double valorAdicional, ITituloPagarModel tituloPagar);
        void SetStatusTitulo(StatusTitulosModel.StatusTitulo status, ITituloPagarModel tituloPagar);


        IEnumerable<TituloPagarModel> GetAll();
        IEnumerable<TituloPagarModel> GetAllByFornecedorId(int fornecedorId);
        TituloPagarModel GetById(int tituloId);
    }
}
