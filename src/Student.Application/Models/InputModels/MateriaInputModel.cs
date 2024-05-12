using Swashbuckle.AspNetCore.Annotations;

namespace Student.Application.Models.InputModels
{
    public class MateriaInputModel
    {
        public MateriaInputModel(string? sDescricao)
        {
            this.sDescricao = sDescricao;
        }

        public MateriaInputModel() { }

        [SwaggerSchema(Description = "Descrição/Nome da Materia")]
        public string? sDescricao { get; set; }
    }
}
