using Student.Application.Models.InputModels;

namespace Student.Application.Services
{
    public interface IAlunoService
    {
        int AddAluno(AlunoInputModel model);
    }
}