﻿using Swashbuckle.AspNetCore.Annotations;

namespace Student.Domain.Entities
{
    public class NotaEntity
    {
        [SwaggerSchema(Description = "Código de idendificação da Nota")]
        public int iCodNota { get; set; }

        [SwaggerSchema(Description = "Código de idendificação do aluno")]
        public int iCodAluno { get; set; }

        [SwaggerSchema(Description = "Código de idendificação da Materia")]
        public int iCodMateria { get; set; }

        [SwaggerSchema(Description = "Nota do Aluno em uma determinada materia")]
        public decimal nNota { get; set; }
    }
}
