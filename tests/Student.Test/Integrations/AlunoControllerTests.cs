using Newtonsoft.Json;
using Student.API.ProgramPartial;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;
using Student.Test.Fixtures;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Student.Test.Integrations
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class AlunoControllerTests(IntegrationTestsFixture<Program> testsFixture)
    {
        private readonly IntegrationTestsFixture<Program> _testsFixture = testsFixture;

        [Fact(DisplayName = "Create a new object Aluno")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_Create_MustReturnAlunoId()
        {
            //Arrage
            var alunoInputModel = new AlunoInputModel
            {
                sNome = "teste",
                dNascimento = DateTime.UtcNow.AddDays(-1),
                sCelular = "12345678",
                sCPF = "1234",
                sEndereco = "Rua teste"
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Post, "api/aluno/create");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(alunoInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode); 
            Assert.NotNull(response);
        }
        
        [Fact(DisplayName = "Get all objects Aluno")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_GetAll_MustReturnAllAlunos()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, "api/aluno/get_all");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode); 
            Assert.NotEmpty(response);
        }
        
        [Fact(DisplayName = "Get Aluno with iCodAluno matching")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_GetById_MustReturnAluno()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, $"api/aluno/get_by_id/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode); 
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Update a object Aluno")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_Update_MustReturnAluno()
        {
            //Arrage
            var alunoInputModel = new AlunoInputModel
            {
                sNome = "bruno",
                sCPF = "1234",
                dNascimento = DateTime.UtcNow,
                sCelular = "123",
                sEndereco = "casa"
            };

            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Patch, $"api/aluno/update/{1}");
            requestObj.Content = new StringContent(JsonConvert.SerializeObject(alunoInputModel), Encoding.UTF8, "application/json");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();
            var objectResult = JsonConvert.DeserializeObject<AlunoDTO>(response);

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotEqual("juao", objectResult?.sNome);
        }

        [Fact(DisplayName = "Delete Aluno with iCodAluno matching")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_Delete_MustReturnTrue()
        {
            //Action
            var requestToken = await _testsFixture.Client.GetAsync("api/auth");
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Delete, $"api/aluno/delete/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.True(bool.Parse(response));
        }

        [Fact(DisplayName = "Get Nota to Aluno with iCodAluno matching")]
        [Trait("Category", "Aluno - Controller")]
        public async void AlunoController_GetNotaAluno_MustReturnNotaValue()
        {
            //Arrange
            var authInputModel = new AuthInputModel
            {
                Nome = "juao",
                Cpf = "1234"
            };

            //Action
            var requestToken = await _testsFixture.Client.PostAsJsonAsync("api/auth", authInputModel);
            var token = await requestToken.Content.ReadAsStringAsync();
            var tokenObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);

            var requestObj = new HttpRequestMessage(HttpMethod.Get, $"api/aluno/consulta_nota/{1}");
            requestObj.Headers.Add("Authorization", $"Bearer {tokenObject?.Values.First()}");

            var request = await _testsFixture.Client.SendAsync(requestObj);
            var response = await request.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
            Assert.NotNull(response);   
        }
    }
}
