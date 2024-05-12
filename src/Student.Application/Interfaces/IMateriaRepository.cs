using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Application.Interfaces
{
    public interface IMateriaRepository
    {
        int Add(MateriaInputModel model);
        List<MateriaEntity?> GetAll();
        MateriaEntity? GetById(int id);
        MateriaEntity? Update(MateriaInputModel aluno, int id);
        bool Delete(int id);
    }
}
