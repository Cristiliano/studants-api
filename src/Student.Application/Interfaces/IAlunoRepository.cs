using Student.Application.Models.InputModels;

namespace Student.Application.Interfaces
{
    public interface IAlunoRepository
    {
        int Add(AlunoInputModel model);
    }
}
