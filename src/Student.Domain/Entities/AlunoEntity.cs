using Swashbuckle.AspNetCore.Annotations;

namespace Student.Domain.Entities
{
    public class AlunoEntity
    {
        [SwaggerSchema(Description = "Código de idendificação do aluno")]
        public int iCodAluno { get; set; }
        
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
