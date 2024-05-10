using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public interface IAlunoService
    {
        int AddAluno(AlunoInputModel model);
        AlunoDTO? GetAlunoByNameCpf(AlunoInputModel model);
    }
}