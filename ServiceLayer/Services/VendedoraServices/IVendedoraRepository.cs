using DomainLayer.Models.Vendedora;

using System.Collections.Generic;

namespace ServiceLayer.Services.VendedoraServices
{
    public interface IVendedoraRepository
    {
        /// <summary>
        /// ADICIONA VENDEDORA
        /// </summary>
        /// <param name="vendedoraModel"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        VendedoraModel Add(IVendedoraModel vendedoraModel);
        
        /// <summary>
        /// ATUALIZA DADOS DE VENDEDORA PASSADA NO PARÂMETRO
        /// </summary>
        /// <param name="vendedoraModel"></param>
        void Update(IVendedoraModel vendedoraModel);
        
        /// <summary>
        /// APAGA REGISTRO DE VENDEDORA NO BANCO DE DADOS
        /// </summary>
        /// <param name="vendedoraModel"></param>
        void Delete(IVendedoraModel vendedoraModel);

        /// <summary>
        /// RETORNA UMA LISTA ENUMERADA DE REGISTRO DE TODAS AS VENDEDORAS
        /// </summary>
        /// <returns type="IEnumerable<IVendedoraModel>">ListaEnumerada de IVendedoraModel</returns>
        IEnumerable<IVendedoraModel> GetAll();

        /// <summary>
        /// RETORNA UMA VENDEDORA PELO ID PASSADO (VENDEDORAID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        VendedoraModel GetById(int id);
        
        /// <summary>
        /// RETORNA UMA VENDEDORA PELO CPF PASSADO
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        VendedoraModel GetByCpf(string cpf);
        
        /// <summary>
        /// ALTERA LETRA DA ROTA DA VENDEDORA
        /// </summary>
        /// <param name="vendedoraId"></param>
        /// <param name="rotaLetraId"></param>
        void AlteraRotaLetra(int vendedoraId, int rotaLetraId);
    }
}
