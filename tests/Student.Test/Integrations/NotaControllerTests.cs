using Newtonsoft.Json;
using Student.API.ProgramPartial;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;
using Student.Test.Fixtures;
using System.Net;
using System.Text;

namespace Student.Test.Integrations
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class NotaControllerTests(IntegrationTestsFixture<Program> testsFixture)
    {
        private readonly IntegrationTestsFixture<Program> _testsFixture = testsFixture;

        [Fact(DisplayName = "Create a new object Nota")]
        [Trait("Category", "Nota - Controller")]
        public async void NotaController_Create_MustReturnNotaId()
        {
            //Arrage
            var notaInputModel = new NotaInputModel
            {
                iCodAluno = 2,
                iCodMateria = 2,
                nNota = 9
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Post, "api/nota/create");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(notaInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Get all objects Nota")]
        [Trait("Category", "Nota - Controller")]
        public async void NotaController_GetAll_MustReturnAllNotas()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, "api/nota/get_all");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotEmpty(response);
        }

        [Fact(DisplayName = "Get Nota with iCodNota matching")]
        [Trait("Category", "Nota - Controller")]
        public async void NotaController_GetById_MustReturnNota()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, $"api/nota/get_by_id/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Update a object Nota")]
        [Trait("Category", "Nota - Controller")]
        public async void NotaController_Update_MustReturnNota()
        {
            //Arrage
            var notaInputModel = new NotaInputModel
            {
                nNota = 3
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Patch, $"api/nota/update/{1}");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(notaInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();
            var objectResult = JsonConvert.DeserializeObject<NotaDTO>(response);

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotEqual(10, objectResult?.nNota);
        }

        [Fact(DisplayName = "Delete Nota with iCodNota matching")]
        [Trait("Category", "Nota - Controller")]
        public async void NotaController_Delete_MustReturnTrue()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Delete, $"api/nota/delete/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.True(bool.Parse(response));
        }
    }
}
