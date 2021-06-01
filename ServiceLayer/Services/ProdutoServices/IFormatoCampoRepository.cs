using DomainLayer.Models.Produtos;

using System.Collections.Generic;

namespace ServiceLayer.Services.ProdutoServices
{
    public interface IFormatoCampoRepository
    {
        IEnumerable<IFormatoCampoModel> GetAll();
        FormatoCampoModel GetByNome(string nomeFormato);
        FormatoCampoModel GetById(int formatoId);
    }
}
