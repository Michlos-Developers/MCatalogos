using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Vendedora;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    [Trait("Category: Model Validations", "Telefone Vendedora")]
    public class TelefoneVendedoraServicesValidationTests : IClassFixture<TelefoneVendedoraServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private TelefoneVendedoraServicesFixture _telVendSerivcesFixture;

        public TelefoneVendedoraServicesValidationTests(TelefoneVendedoraServicesFixture telefoneVendedoraServicesFixture, 
            ITestOutputHelper testOutputHelper)
        {
            _telVendSerivcesFixture = telefoneVendedoraServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception = Record.Exception(() => _telVendSerivcesFixture.TelefoneVendedoraServices
            .ValidateModelDataAnnotatios(_telVendSerivcesFixture.TelefoneVendedoraModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);

        }

        [Fact]
        public void ExceptionIfMoreThenElevenChars()
        {
            _telVendSerivcesFixture.TelefoneVendedoraModel.Numero = "(61)999-943-234";//MAIOR QUE 11.

            CallExceptionVAlidateDataAnnotation();

        }
        
        [Fact]
        public void ExceptionIfOlnyNumberWithoutLetters()
        {
            _telVendSerivcesFixture.TelefoneVendedoraModel.Numero = "613399319a";//DEVE ACEITAR SOMENTE NÚMEROS.

            CallExceptionVAlidateDataAnnotation();

        }
        [Fact]
        public void ExceptionIfOlnyNumberWithoutSpecChars()
        {
            _telVendSerivcesFixture.TelefoneVendedoraModel.Numero = "3199-3199";//DEVE ACEITAR SOMENTE NÚMEROS.

            CallExceptionVAlidateDataAnnotation();

        }

        [Fact]
        public void ExceptionIfEmptyValues()
        {
            _telVendSerivcesFixture.TelefoneVendedoraModel.Numero = "";//NÃO DEVE ACEITAR VALOR NULLO.

            CallExceptionVAlidateDataAnnotation();

        }

        private void CallExceptionVAlidateDataAnnotation()
        {
            Exception exception =
                            Assert.Throws<ArgumentException>(testCode: () => _telVendSerivcesFixture.TelefoneVendedoraServices.ValidateModelDataAnnotatios
                            (_telVendSerivcesFixture.TelefoneVendedoraModel));

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
                StringBuilder sb = new StringBuilder();
                JObject json = JObject.FromObject(_telVendSerivcesFixture.TelefoneVendedoraModel);
                sb.Append("***** NO EXCEPTION WAS THROW *****").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    sb.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(sb.ToString());
            }
        }

        private void SetValidSampleValues()
        {
            _telVendSerivcesFixture.TelefoneVendedoraModel.TelefoneId = 1;
            _telVendSerivcesFixture.TelefoneVendedoraModel.Numero = "61999943234";
            _telVendSerivcesFixture.TelefoneVendedoraModel.TipoTelefoneId = 5;
            _telVendSerivcesFixture.TelefoneVendedoraModel.TipoTelefone = new TipoTelefoneModel 
            { TipoId = int.Parse(_telVendSerivcesFixture.TelefoneVendedoraModel.TipoTelefoneId.ToString()) };
            _telVendSerivcesFixture.TelefoneVendedoraModel.VendedoraId = 1;
            _telVendSerivcesFixture.TelefoneVendedoraModel.Vendedora = new VendedoraModel 
            { VendedoraId = int.Parse(_telVendSerivcesFixture.TelefoneVendedoraModel.VendedoraId.ToString()) };
        }
    }
}
