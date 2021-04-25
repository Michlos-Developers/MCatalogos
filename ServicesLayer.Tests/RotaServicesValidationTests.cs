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
    [Trait("Category", "Rota Model Validations")]
    public class RotaServicesValidationTests : IClassFixture<RotaServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private RotaServicesFixture _rotaServicesFixture;

        public RotaServicesValidationTests(RotaServicesFixture rotaServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._rotaServicesFixture = rotaServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();

        }

        [Fact]
        public void ShouldNotThrowExpceptionForDefaultTestValuesOnAnnotations()
        {
            var exception = Record.Exception(() => _rotaServicesFixture.RotaServices.ValidateModelDataAnnotations(_rotaServicesFixture.RotaModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _rotaServicesFixture.RotaModel.Letra = "9";//SOMENTE LETRAS
            _rotaServicesFixture.RotaModel.Numero = "A";//SOMENTE NÚMEROS

            CallExecptionValidateDataAnnotation();
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
                JObject json = JObject.FromObject(_rotaServicesFixture.RotaModel);
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
            _rotaServicesFixture.RotaModel.RotaId = 1;
            _rotaServicesFixture.RotaModel.Letra = "A";
            _rotaServicesFixture.RotaModel.Numero = "01";
        }

        private void CallExecptionValidateDataAnnotation()
        {

            Exception exception =
                            Assert.Throws<ArgumentException>(testCode: () => _rotaServicesFixture.RotaServices.ValidateModelDataAnnotations
                            (_rotaServicesFixture.RotaModel));

            WriteExceptionTestResult(exception);
        }


    }
}
