using Student.Application.Models.InputModels;
using Student.Domain.DTOs;
using Student.Domain.Entities;

namespace Student.Test.Fixtures
{
    [CollectionDefinition(nameof(StudentCollection))]
    public class StudentCollection : ICollectionFixture<StudentFixture> { }
    public class StudentFixture : IDisposable 
    {
        public AlunoInputModel AlunoInputModelValid { get; set; }
        public MateriaInputModel MateriaInputModelValid { get; set; }
        public NotaInputModel NotaInputModelValid { get; set; }

        public AlunoEntity AlunoEntityValid { get; set; }
        public MateriaEntity MateriaEntityValid { get; set; }
        public NotaEntity NotaEntityValid { get; set; }


        public AlunoDTO AlunoDTOValid { get; set; }
        public MateriaDTO MateriaDTOValid { get; set; }
        public NotaDTO NotaDTOValid { get; set; }

        public StudentFixture() => Setup();

        public void Setup()
        {
            AlunoInputModelValid = new AlunoInputModel
            {
                sNome = "Carlos",
                dNascimento = DateTime.Today,
                sCelular = "12345678",
                sCPF = "12345",
                sEndereco = "teste"
            };

            AlunoEntityValid = new AlunoEntity
            {
                sNome = "Carlos",
                dNascimento = DateTime.Today,
                sCelular = "12345678",
                sCPF = "12345",
                sEndereco = "teste",
                iCodAluno = 12
            };

            AlunoDTOValid = new AlunoDTO(AlunoEntityValid);

            MateriaInputModelValid = new MateriaInputModel
            {
                sDescricao = "teste"
            };

            MateriaEntityValid = new MateriaEntity
            {
                iCodMateria = 12,
                sDescricao = "teste"
            };

            MateriaDTOValid = new MateriaDTO(MateriaEntityValid);

            NotaInputModelValid = new NotaInputModel
            {
                iCodAluno = 12,
                iCodMateria = 12,
                nNota = 10,
            };

            NotaEntityValid = new NotaEntity
            {
                iCodNota = 12,
                iCodAluno = 12,
                iCodMateria = 12,
                nNota = 10,
            };

            NotaDTOValid = new NotaDTO(NotaEntityValid);
        }

        public void Dispose() => Setup();
    }
}
