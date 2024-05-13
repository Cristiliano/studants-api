using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

namespace Student.Application.Services
{
    public class AlunoService(IAlunoRepository alunoRepository, INotaRepository notaRepository) : IAlunoService
    {
        private readonly IAlunoRepository _repository = alunoRepository;
        private readonly INotaRepository _notaRepository = notaRepository;

        public int AddAluno(AlunoInputModel model)
        {
            try
            {
                var alunoId = _repository.Add(model);

                return alunoId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public AlunoDTO? GetAlunoByNameCpf(AlunoInputModel model)
        {
            try
            {
                var aluno = _repository.GetByNameCpf(model.sNome, model.sCPF);

                if (aluno is null)
                {
                    return new AlunoDTO();
                }

                return new AlunoDTO(aluno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public AlunoDTO? GetById(int id)
        {
            try
            {
                var aluno = _repository.GetById(id);

                if (aluno is null)
                {
                    return new AlunoDTO();
                }

                return new AlunoDTO(aluno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<AlunoDTO?> GetAll()
        {
            try
            {
                var alunos = _repository.GetAll();

                if (alunos.Count == 0)
                {
                    return new List<AlunoDTO?>();
                }

                return alunos.Select(a => new AlunoDTO(a)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public AlunoDTO? Update(AlunoInputModel model, int id)
        {
            try
            {
                var aluno = _repository.Update(model, id);

                if (aluno is null)
                {
                    return new AlunoDTO();
                }

                return new AlunoDTO(aluno);
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

        public decimal GetNotaAluno(int id)
        {
            try
            {
                var aluno = GetById(id);

                if(aluno is null)
                {
                    return 0;
                }

                return _notaRepository.GetNotaAluno(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
