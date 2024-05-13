using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public class NotaService(INotaRepository repository) : INotaService
    {
        public readonly INotaRepository _repository = repository;

        public int AddNota(NotaInputModel model)
        {
            try
            {
                var notaId = _repository.Add(model);

                return notaId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public NotaDTO? GetById(int id)
        {
            try
            {
                var nota = _repository.GetById(id);

                if (nota is null)
                {
                    return new NotaDTO();
                }

                return new NotaDTO(nota);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<NotaDTO?> GetAll()
        {
            try
            {
                var notas = _repository.GetAll();

                if (notas.Count == 0)
                {
                    return new List<NotaDTO?>();
                }

                return notas.Select(a => new NotaDTO(a)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public NotaDTO? Update(NotaInputModel model, int id)
        {
            try
            {
                var nota = _repository.Update(model, id);

                if (nota is null)
                {
                    return null;
                }

                return new NotaDTO(nota);
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
