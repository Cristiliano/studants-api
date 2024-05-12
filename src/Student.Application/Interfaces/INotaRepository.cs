using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Application.Interfaces
{
    public interface INotaRepository
    {
        int Add(NotaInputModel model);
        List<NotaEntity?> GetAll();
        NotaEntity? GetById(int id);
        NotaEntity? Update(NotaInputModel aluno, int id);
        bool Delete(int id);
    }
}
