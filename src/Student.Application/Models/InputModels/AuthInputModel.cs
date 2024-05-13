using Swashbuckle.AspNetCore.Annotations;

namespace Student.Application.Models.InputModels
{
    public class AuthInputModel
    {
        public AuthInputModel() {}

        public AuthInputModel(string? nome, string? cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }

        [SwaggerSchema(Description = "Nome do aluno")]
        public string? Nome { get; set; }

        [SwaggerSchema(Description = "CPF do aluno")]
        public string? Cpf { get; set; }
    }
}
