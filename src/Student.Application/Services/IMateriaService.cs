using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public interface IMateriaService
    {
        int AddMateria(MateriaInputModel model);
        bool Delete(int id);
        List<MateriaDTO?> GetAll();
        MateriaDTO? GetById(int id);
        MateriaDTO? Update(MateriaInputModel model, int id);
    }
}