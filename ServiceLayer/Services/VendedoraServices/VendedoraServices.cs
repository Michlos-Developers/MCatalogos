using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServiceLayer.Services.VendedoraServices
{

    public class VendedoraServices : IVendedoraService, IVendedoraRepository
    {
        private IVendedoraRepository _vendedoraRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        /// <summary>
        /// MÉTODO PRINCIPAL DO SERVIÇO
        /// RECEBE OS PARAMETROS E ATRIBUI OS VALORES DOS PARAMETROS ÀS INTERFACES.
        /// </summary>
        /// <param name="vendedoraRepository"></param>
        /// <param name="modelDataAnnotationCheck"></param>
        public VendedoraServices(IVendedoraRepository vendedoraRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _vendedoraRepository = vendedoraRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        /// <summary>
        /// MÉTODO QUE ADICIONA VENDEDORA AO SISTEMA.
        /// CHAMA A INTERFACE IVendedoraRepository
        /// </summary>
        /// <param name="vendedoraModel"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        public VendedoraModel Add(IVendedoraModel vendedoraModel)
        {
            return _vendedoraRepository.Add(vendedoraModel);
        }

        /// <summary>
        /// ATUALIZA OS DADOS DA VENDEDORA PASSADA COMO PARÂMETRO
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public void Update(IVendedoraModel vendedoraModel)
        {
            _vendedoraRepository.Update(vendedoraModel);
        }

        /// <summary>
        /// APAGA O REGISTRO DA VENDEDORA NO BANCO DE DADOS.
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public void Delete(IVendedoraModel vendedoraModel)
        {
            _vendedoraRepository.Delete(vendedoraModel);
        }

        /// <summary>
        /// BUSCA TODAS AS VENDEDORAS CADASTRADAS NO BANCO DE DADOS.
        /// </summary>
        /// <returns type="IEnumerable">VendedoraList</returns>
        public IEnumerable<IVendedoraModel> GetAll()
        {
            return _vendedoraRepository.GetAll();
        }

        /// <summary>
        /// BUSCA APENAS UMA VENDEDORA PELO CAMPO VendedoraId
        /// </summary>
        /// <param name="id"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        public VendedoraModel GetById(int id)
        {
            return _vendedoraRepository.GetById(id);
        }

        /// <summary>
        /// RETORNA UMA VENDEDORA PELO CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns type="VendedoraModel">VendedoraModel</returns>
        public VendedoraModel GetByCpf(string cpf)
        {
            return _vendedoraRepository.GetByCpf(cpf);
        }

        /// <summary>
        /// ALTERA A LETRA DA ROA TA VENDEDORA
        /// </summary>
        /// <param name="vendedoraId"></param>
        /// <param name="rotaLetraId"></param>
        public void AlteraRotaLetra(int vendedoraId, int rotaLetraId)
        {
            _vendedoraRepository.AlteraRotaLetra(vendedoraId, rotaLetraId);
        }

        /// <summary>
        /// VALIDAÇÃO DE DADOS DO MODEL
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public void ValidateModelDataAnnotations(IVendedoraModel vendedoraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(vendedoraModel);
            
        }

        /// <summary>
        /// VALIDAÇÃO DOS DADOS DO MODEL
        /// </summary>
        /// <param name="vendedoraModel"></param>
        public void ValidateModel(IVendedoraModel vendedoraModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(vendedoraModel);

        }


    }
}
