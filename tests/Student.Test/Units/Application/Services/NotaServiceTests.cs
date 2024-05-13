using Moq.AutoMock;
using Moq;
using Student.Application.Interfaces;
using Student.Application.Services;
using Student.Domain.Entities;
using Student.Test.Fixtures;

namespace Student.Test.Units.Application.Services
{
    [Collection(nameof(StudentCollection))]
    public class NotaServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<INotaRepository> _notaRepositoryMock;
        private readonly StudentFixture _studentFixture;
        private readonly NotaService _notaService;

        public NotaServiceTests(StudentFixture studentFixture)
        {
            _mocker = new AutoMocker();
            _notaRepositoryMock = _mocker.GetMock<INotaRepository>();
            _studentFixture = studentFixture;
            _notaService = new NotaService(_notaRepositoryMock.Object);
        }

        [Fact(DisplayName = "Add object Nota")]
        [Trait("Category", "Nota - Service")]
        public async void NotaService_Create_MustReturnNotaId()
        {
            //Arrange
            var inputModel = _studentFixture.NotaInputModelValid;
            var entity = _studentFixture.NotaEntityValid;

            _notaRepositoryMock.Setup(x => x.Add(inputModel))
                               .Returns(entity.iCodNota);

            //Action
            var result = _notaService.AddNota(inputModel);

            //Assert
            Assert.Equal(entity.iCodNota, result);
        }

        [Fact(DisplayName = "Get Nota By Id")]
        [Trait("Category", "Nota - Service")]
        public async void NotaService_GetNotaById_MustReturnNota()
        {
            //Arrange
            var entity = _studentFixture.NotaEntityValid;

            _notaRepositoryMock.Setup(x => x.GetById(entity.iCodNota))
                                  .Returns(entity);

            //Action
            var result = _notaService.GetById(entity.iCodNota);

            //Assert
            Assert.Equal(entity.nNota, result?.nNota);
        }

        [Fact(DisplayName = "Get All Nota")]
        [Trait("Category", "Nota - Service")]
        public async void NotaService_GetAll_MustReturnNotaList()
        {
            //Arrange
            var entity = _studentFixture.NotaEntityValid;
            var entityList = new List<NotaEntity> { entity };

            _notaRepositoryMock.Setup(x => x.GetAll())
                                .Returns(entityList);

            //Action
            var result = _notaService.GetAll();

            //Assert
            Assert.Equal(entity.nNota, result?.First()?.nNota);
        }

        [Fact(DisplayName = "Update Nota")]
        [Trait("Category", "Nota - Service")]
        public async void NotaService_Update_MustReturnNota()
        {
            //Arrange
            var inputModel = _studentFixture.NotaInputModelValid;
            inputModel.nNota = 2;
            var entity = _studentFixture.NotaEntityValid;
            entity.nNota = 2;

            _notaRepositoryMock.Setup(x => x.Update(inputModel, entity.iCodNota))
                                  .Returns(entity);

            //Action
            var result = _notaService.Update(inputModel, entity.iCodNota);

            //Assert
            Assert.Equal(entity.nNota, result?.nNota);
        }

        [Fact(DisplayName = "Delete Nota")]
        [Trait("Category", "Nota - Service")]
        public async void NotaService_Delete_MustReturnTrue()
        {
            //Arrange
            var entity = _studentFixture.NotaEntityValid;

            _notaRepositoryMock.Setup(x => x.Delete(entity.iCodNota))
                                .Returns(true);

            //Action
            var result = _notaService.Delete(entity.iCodNota);

            //Assert
            Assert.True(result);
        }
    }
}
