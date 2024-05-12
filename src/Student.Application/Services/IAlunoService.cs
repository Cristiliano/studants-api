using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public interface IAlunoService
    {
        int AddAluno(AlunoInputModel model);
        AlunoDTO? GetAlunoByNameCpf(AlunoInputModel model);
        List<AlunoDTO?> GetAll();
        AlunoDTO? GetById(int id);
        AlunoDTO? Update(AlunoInputModel model, int id);
        bool Delete(int id);
        decimal GetNotaAluno(int id);
    }
}