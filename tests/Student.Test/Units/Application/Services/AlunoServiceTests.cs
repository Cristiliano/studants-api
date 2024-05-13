using Student.Test.Fixtures;
using Moq;
using Moq.AutoMock;
using Student.Application.Interfaces;
using Student.Application.Services;
using Student.Domain.DTOs;
using Student.Domain.Entities;

namespace Student.Test.Units.Application.Services
{
    [Collection(nameof(StudentCollection))]
    public class AlunoServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock;
        private readonly Mock<INotaRepository> _notaRepositoryMock;
        private readonly StudentFixture _studentFixture;
        private readonly AlunoService _alunoService;

        public AlunoServiceTests(StudentFixture studentFixture) 
        {
            _studentFixture = studentFixture;
            _mocker = new AutoMocker();
            _alunoRepositoryMock = _mocker.GetMock<IAlunoRepository>();
            _notaRepositoryMock = _mocker.GetMock<INotaRepository>();
            _alunoService = new AlunoService(_alunoRepositoryMock.Object, _notaRepositoryMock.Object);
        }

        [Fact(DisplayName = "Add object Aluno")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_Create_MustReturnAlunoId()
        {
            //Arrange
            var inputModel = _studentFixture.AlunoInputModelValid;
            var entity = _studentFixture.AlunoEntityValid;

            _alunoRepositoryMock.Setup(x => x.Add(inputModel))
                                .Returns(entity.iCodAluno);

            //Action
            var result = _alunoService.AddAluno(inputModel);

            //Assert
            Assert.Equal(entity.iCodAluno, result);
        }

        [Fact(DisplayName = "Get Aluno By Name and Cpf")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_GetAlunoByNameCpf_MustReturnAluno()
        {
            //Arrange
            var inputModel = _studentFixture.AlunoInputModelValid;
            var entity = _studentFixture.AlunoEntityValid;

            _alunoRepositoryMock.Setup(x => x.GetByNameCpf(inputModel.sNome, inputModel.sCPF))
                                .Returns(entity);

            //Action
            var result = _alunoService.GetAlunoByNameCpf(inputModel);

            //Assert
            Assert.Equal(entity.sNome, result?.sNome);
            Assert.Equal(entity.dNascimento, result?.dNascimento);
        }

        [Fact(DisplayName = "Get Aluno By Id")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_GetAlunoById_MustReturnAluno()
        {
            //Arrange
            var entity = _studentFixture.AlunoEntityValid;

            _alunoRepositoryMock.Setup(x => x.GetById(entity.iCodAluno))
                                .Returns(entity);

            //Action
            var result = _alunoService.GetById(entity.iCodAluno);

            //Assert
            Assert.Equal(entity.sNome, result?.sNome);
            Assert.Equal(entity.dNascimento, result?.dNascimento);
        }

        [Fact(DisplayName = "Get All Alunos")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_GetAll_MustReturnAlunoList()
        {
            //Arrange
            var entity = _studentFixture.AlunoEntityValid;
            var entityList = new List<AlunoEntity> { entity };

            _alunoRepositoryMock.Setup(x => x.GetAll())
                                .Returns(entityList);

            //Action
            var result = _alunoService.GetAll();

            //Assert
            Assert.Equal(entity.sNome, result?.First()?.sNome);
            Assert.Equal(entity.dNascimento, result?.First()?.dNascimento);
        }

        [Fact(DisplayName = "Update Aluno")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_Update_MustReturnAluno()
        {
            //Arrange
            var inputModel = _studentFixture.AlunoInputModelValid;
            inputModel.sNome = "xpto";
            var entity = _studentFixture.AlunoEntityValid;
            entity.sNome = "xpto";

            _alunoRepositoryMock.Setup(x => x.Update(inputModel, entity.iCodAluno))
                                .Returns(entity);

            //Action
            var result = _alunoService.Update(inputModel, entity.iCodAluno);

            //Assert
            Assert.Equal(entity.sNome, result?.sNome);
            Assert.Equal(entity.dNascimento, result?.dNascimento);
        }

        [Fact(DisplayName = "Delete Aluno")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_Delete_MustReturnTrue()
        {
            //Arrange
            var entity = _studentFixture.AlunoEntityValid;

            _alunoRepositoryMock.Setup(x => x.Delete(entity.iCodAluno))
                                .Returns(true);

            //Action
            var result = _alunoService.Delete(entity.iCodAluno);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Get Nota Aluno")]
        [Trait("Category", "Aluno - Service")]
        public async void AlunoService_GetNotaAluno_MustReturnValue()
        {
            //Arrange
            var entity = _studentFixture.AlunoEntityValid;
            var notaEntity = _studentFixture.NotaEntityValid;

            _notaRepositoryMock.Setup(x => x.GetNotaAluno(entity.iCodAluno))
                               .Returns(notaEntity.nNota);

            //Action
            var result = _alunoService.GetNotaAluno(entity.iCodAluno);

            //Assert
            Assert.Equal(notaEntity.nNota, result);
        }
    }
}
