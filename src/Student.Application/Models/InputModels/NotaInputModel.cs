using Swashbuckle.AspNetCore.Annotations;

namespace Student.Application.Models.InputModels
{
    public class NotaInputModel
    {
        public NotaInputModel() {}

        public NotaInputModel(int iCodAluno, int iCodMateria, decimal nNota)
        {
            this.iCodAluno = iCodAluno;
            this.iCodMateria = iCodMateria;
            this.nNota = nNota;
        }

        [SwaggerSchema(Description = "Código de idendificação do aluno")]
        public int iCodAluno { get; set; }

        [SwaggerSchema(Description = "Código de idendificação da Materia")]
        public int iCodMateria { get; set; }

        [SwaggerSchema(Description = "Nota do Aluno em uma determinada materia")]
        public decimal nNota { get; set; }
    }
}
