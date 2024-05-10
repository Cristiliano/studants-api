using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Application.Interfaces
{
    public interface IAlunoRepository
    {
        int Add(AlunoInputModel model);
        AlunoEntity? GetByNameCpf(string? name, string? cpf);
    }
}
