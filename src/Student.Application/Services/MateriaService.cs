using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public class MateriaService(IMateriaRepository repository) : IMateriaService
    {
        private readonly IMateriaRepository _repository = repository;

        public int AddMateria(MateriaInputModel model)
        {
            try
            {
                var materiaId = _repository.Add(model);

                return materiaId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public MateriaDTO? GetById(int id)
        {
            try
            {
                var materia = _repository.GetById(id);

                if (materia is null)
                {
                    return new MateriaDTO();
                }

                return new MateriaDTO(materia);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<MateriaDTO?> GetAll()
        {
            try
            {
                var materias = _repository.GetAll();

                if (materias.Count == 0)
                {
                    return new List<MateriaDTO?>();
                }

                return materias.Select(a => new MateriaDTO(a)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public MateriaDTO? Update(MateriaInputModel model, int id)
        {
            try
            {
                var materia = _repository.Update(model, id);

                if (materia is null)
                {
                    return null;
                }

                return new MateriaDTO(materia);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
