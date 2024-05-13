using Moq.AutoMock;
using Moq;
using Student.Application.Interfaces;
using Student.Application.Services;
using Student.Test.Fixtures;
using Student.Domain.Entities;

namespace Student.Test.Units.Application.Services
{
    [Collection(nameof(StudentCollection))]
    public class MateriaServiceTest
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IMateriaRepository> _materiaRepositoryMock;
        private readonly StudentFixture _studentFixture;
        private readonly MateriaService _materiaService;

        public MateriaServiceTest(StudentFixture studentFixture)
        {
            _mocker = new AutoMocker();
            _materiaRepositoryMock = _mocker.GetMock<IMateriaRepository>(); 
            _studentFixture = studentFixture;
            _materiaService = new MateriaService(_materiaRepositoryMock.Object);
        }

        [Fact(DisplayName = "Add object Materia")]
        [Trait("Category", "Materia - Service")]
        public async void MateriaService_Create_MustReturnMateriaId()
        {
            //Arrange
            var inputModel = _studentFixture.MateriaInputModelValid;
            var entity = _studentFixture.MateriaEntityValid;

            _materiaRepositoryMock.Setup(x => x.Add(inputModel))
                                .Returns(entity.iCodMateria);

            //Action
            var result = _materiaService.AddMateria(inputModel);

            //Assert
            Assert.Equal(entity.iCodMateria, result);
        }

        [Fact(DisplayName = "Get Materia By Id")]
        [Trait("Category", "Materia - Service")]
        public async void MateriaService_GetMateriaById_MustReturnMateria()
        {
            //Arrange
            var entity = _studentFixture.MateriaEntityValid;

            _materiaRepositoryMock.Setup(x => x.GetById(entity.iCodMateria))
                                  .Returns(entity);

            //Action
            var result = _materiaService.GetById(entity.iCodMateria);

            //Assert
            Assert.Equal(entity.sDescricao, result?.sDescricao);
        }

        [Fact(DisplayName = "Get All Materia")]
        [Trait("Category", "Materia - Service")]
        public async void MateriaService_GetAll_MustReturnMateriaList()
        {
            //Arrange
            var entity = _studentFixture.MateriaEntityValid;
            var entityList = new List<MateriaEntity> { entity };

            _materiaRepositoryMock.Setup(x => x.GetAll())
                                .Returns(entityList);

            //Action
            var result = _materiaService.GetAll();

            //Assert
            Assert.Equal(entity.sDescricao, result?.First()?.sDescricao);
        }

        [Fact(DisplayName = "Update Materia")]
        [Trait("Category", "Materia - Service")]
        public async void MateriaService_Update_MustReturnMateria()
        {
            //Arrange
            var inputModel = _studentFixture.MateriaInputModelValid;
            inputModel.sDescricao = "xpto";
            var entity = _studentFixture.MateriaEntityValid;
            entity.sDescricao = "xpto";

            _materiaRepositoryMock.Setup(x => x.Update(inputModel, entity.iCodMateria))
                                  .Returns(entity);

            //Action
            var result = _materiaService.Update(inputModel, entity.iCodMateria);

            //Assert
            Assert.Equal(entity.sDescricao, result?.sDescricao);
        }

        [Fact(DisplayName = "Delete Materia")]
        [Trait("Category", "Materia - Service")]
        public async void MateriaService_Delete_MustReturnTrue()
        {
            //Arrange
            var entity = _studentFixture.MateriaEntityValid;

            _materiaRepositoryMock.Setup(x => x.Delete(entity.iCodMateria))
                                .Returns(true);

            //Action
            var result = _materiaService.Delete(entity.iCodMateria);

            //Assert
            Assert.True(result);
        }
    }
}
