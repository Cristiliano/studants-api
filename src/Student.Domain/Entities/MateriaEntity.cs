using Swashbuckle.AspNetCore.Annotations;

namespace Student.Domain.Entities
{
    public class MateriaEntity
    {
        [SwaggerSchema(Description = "Código de idendificação da Materia")]
        public int iCodMateria { get; set; }

        [SwaggerSchema(Description = "Descrição/Nome da Materia")]
        public string? sDescricao { get; set; }
    }
}
