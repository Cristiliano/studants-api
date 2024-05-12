using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public interface INotaService
    {
        int AddNota(NotaInputModel model);
        bool Delete(int id);
        List<NotaDTO?> GetAll();
        NotaDTO? GetById(int id);
        NotaDTO? Update(NotaInputModel model, int id);
    }
}