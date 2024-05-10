using Swashbuckle.AspNetCore.Annotations;

namespace Student.Application.Models.InputModels
{
    public class AlunoInputModel
    {
        public AlunoInputModel(string? sNome, DateTime? dNascimento, string? sCPF, string? sEndereco, string? sCelular)
        {
            this.sNome = sNome;
            this.dNascimento = dNascimento;
            this.sCPF = sCPF;
            this.sEndereco = sEndereco;
            this.sCelular = sCelular;
        }

        public AlunoInputModel(string? sNome, string? sCPF) 
        {
            this.sNome = sNome; 
            this.sCPF = sCPF;
        }

        public AlunoInputModel() { }

        [SwaggerSchema(Description = "Nome do aluno")]
        public string? sNome { get; set; }

        [SwaggerSchema(Description = "Data de nascimento do aluno")]
        public DateTime? dNascimento { get; set; }

        [SwaggerSchema(Description = "CPF do aluno")]
        public string? sCPF { get; set; }

        [SwaggerSchema(Description = "Endereço")]
        public string? sEndereco { get; set; }

        [SwaggerSchema(Description = "Número de cell do aluno")]
        public string? sCelular { get; set; }
    }
}
