using Student.Domain.Entities;

namespace Student.Domain.DTOs
{
    public class NotaDTO : NotaEntity
    {
        public NotaDTO(NotaEntity nota) 
        {
            iCodNota = nota.iCodNota;
            iCodAluno = nota.iCodAluno;
            iCodMateria = nota.iCodMateria;
            nNota = nota.nNota;
        }
    }
}
