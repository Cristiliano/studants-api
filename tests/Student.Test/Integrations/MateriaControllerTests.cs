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
    public class MateriaControllerTests(IntegrationTestsFixture<Program> testsFixture)
    {
        private readonly IntegrationTestsFixture<Program> _testsFixture = testsFixture;

        [Fact(DisplayName = "Create a new object Materia")]
        [Trait("Category", "Materia - Controller")]
        public async void MateriaController_Create_MustReturnMateriaId()
        {
            //Arrage
            var materiaInputModel = new MateriaInputModel
            {
                sDescricao = "Xamarim"
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Post, "api/materia/create");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(materiaInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Get all objects Materia")]
        [Trait("Category", "Materia - Controller")]
        public async void MateriaController_GetAll_MustReturnAllMaterias()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, "api/materia/get_all");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotEmpty(response);
        }

        [Fact(DisplayName = "Get Materia with iCodMateria matching")]
        [Trait("Category", "Materia - Controller")]
        public async void MateriaController_GetById_MustReturnMateria()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, $"api/materia/get_by_id/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Update a object Materia")]
        [Trait("Category", "Materia - Controller")]
        public async void MateriaController_Update_MustReturnMateria()
        {
            //Arrage
            var materiaInputModel = new MateriaInputModel
            {
                sDescricao = "XPTO"
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Patch, $"api/materia/update/{1}");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(materiaInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();
            var objectResult = JsonConvert.DeserializeObject<MateriaDTO>(response);

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotEqual("Matematica", objectResult?.sDescricao);
        }

        [Fact(DisplayName = "Delete Materia with iCodMateria matching")]
        [Trait("Category", "Materia - Controller")]
        public async void MateriaController_Delete_MustReturnTrue()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Delete, $"api/materia/delete/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.True(bool.Parse(response));
        }
    }
}
