using Student.Domain.Entities;

namespace Student.Domain.DTOs
{
    public class MateriaDTO : MateriaEntity
    {
        public MateriaDTO() { }

        public MateriaDTO(MateriaEntity materia) 
        {
            iCodMateria = materia.iCodMateria;
            sDescricao = materia.sDescricao;
        }
    }
}
