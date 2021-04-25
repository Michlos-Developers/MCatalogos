using DomainLayer.Models.CommonModels.Address;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    [Trait("Category", "Vendedora Model Validations")]
    public class VendedoraServicesValidationTests : IClassFixture<VendedoraServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private VendedoraServicesFixture _vendedoraServicesFixture;

        public VendedoraServicesValidationTests(VendedoraServicesFixture vendedoraServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._vendedoraServicesFixture = vendedoraServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();

        }

        [Fact]
        public void ShouldNotThrowExpceptionForDefaultTestValuesOnAnnotations()
        {
            var exception =
                Record.Exception(() => _vendedoraServicesFixture.VendedoraServices.ValidateModelDataAnnotations
                (_vendedoraServicesFixture.VendedoraModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _vendedoraServicesFixture.VendedoraModel.Nome = "Adriana"; //menor que 10 caracteres
            _vendedoraServicesFixture.VendedoraModel.Cpf = "820951";// menos que 11 caracteres
            _vendedoraServicesFixture.VendedoraModel.Email = "adriana2gmail.com";//email errado
            _vendedoraServicesFixture.VendedoraModel.NomeConjuge = "Michael";//menor que 10 caracteres
            _vendedoraServicesFixture.VendedoraModel.NomePai = "Eduardo";//menor que 10 caracteres
            _vendedoraServicesFixture.VendedoraModel.NomeMae = "Genilza";//menor que 10 caracteres
            _vendedoraServicesFixture.VendedoraModel.Logradouro = ""; //campo vazio requerido
            _vendedoraServicesFixture.VendedoraModel.Numero = ""; // campo vazio requerido
            

            CallExecptionValidateDataAnnotation();
        }


        [Fact]
        private void ShouldThrowExceptionForCpfEmpty()
        {

            _vendedoraServicesFixture.VendedoraModel.Cpf = "";
            CallExecptionValidateDataAnnotation();
        }

        [Fact]
        private void ShouldThrowExceptionForCpfWithOtherChar()
        {
            _vendedoraServicesFixture.VendedoraModel.Cpf = "820.951.751-15"; //somente numéricos
            CallExecptionValidateDataAnnotation();
        }

        [Fact]
        private void ShouldThrowExceptionForCpfLong()
        {
            _vendedoraServicesFixture.VendedoraModel.Cpf = "820951751155"; //mais que 11 caracteres
            CallExecptionValidateDataAnnotation();
        }

        [Fact]
        private void ShouldThrowExceptionForRgEmpty()
        {
            _vendedoraServicesFixture.VendedoraModel.Rg = "";
            CallExecptionValidateDataAnnotation();
        }
        
        private void CallExecptionValidateDataAnnotation()
        {
            
            Exception exception =
                            Assert.Throws<ArgumentException>(testCode: () => _vendedoraServicesFixture.VendedoraServices.ValidateModelDataAnnotations
                            (_vendedoraServicesFixture.VendedoraModel));

            WriteExceptionTestResult(exception);
        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                JObject json = JObject.FromObject(_vendedoraServicesFixture.VendedoraModel);
                stringBuilder.Append("***** NO EXCEPTION WAS THROW *****").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }

        private void SetValidSampleValues()
        {
            _vendedoraServicesFixture.VendedoraModel.VendedoraId = 1;
            _vendedoraServicesFixture.VendedoraModel.Nome = "Adriana de Araujo Lima";
            _vendedoraServicesFixture.VendedoraModel.Cpf = "82095175115";
            _vendedoraServicesFixture.VendedoraModel.DataNascimento = new DateTime(1976, 10, 30, 00, 00, 00);
            _vendedoraServicesFixture.VendedoraModel.Email = "adriana@gmail.com";
            _vendedoraServicesFixture.VendedoraModel.Rg = "123456789";
            _vendedoraServicesFixture.VendedoraModel.RgEmissor = "SSP";
            _vendedoraServicesFixture.VendedoraModel.UfRgId = 27;
            _vendedoraServicesFixture.VendedoraModel.NomePai = "Eduardo Roberto Alves de Lima";
            _vendedoraServicesFixture.VendedoraModel.NomeMae = "Genilza de Araujo Lima";
            _vendedoraServicesFixture.VendedoraModel.NomeConjuge = "Michael Xavier Lima";
            _vendedoraServicesFixture.VendedoraModel.Logradouro = "QN 7, Conjunto 3";
            _vendedoraServicesFixture.VendedoraModel.Numero = "25";
            _vendedoraServicesFixture.VendedoraModel.UfRg = new EstadoModel { EstadoId = _vendedoraServicesFixture.VendedoraModel.UfRgId };
            _vendedoraServicesFixture.VendedoraModel.EstadoId = 27;
            _vendedoraServicesFixture.VendedoraModel.Estado = new EstadoModel { EstadoId = _vendedoraServicesFixture.VendedoraModel.EstadoId };
            _vendedoraServicesFixture.VendedoraModel.CidadeId = 1;
            _vendedoraServicesFixture.VendedoraModel.Cidade = new CidadeModel { CidadeId = _vendedoraServicesFixture.VendedoraModel.CidadeId };
            _vendedoraServicesFixture.VendedoraModel.BairroId = 2;
            _vendedoraServicesFixture.VendedoraModel.Bairro = new BairroModel { BairroId = _vendedoraServicesFixture.VendedoraModel.BairroId };
        }
    }
}
