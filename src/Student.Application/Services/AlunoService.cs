using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;
using System.Reflection;

namespace Student.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public int AddAluno(AlunoInputModel model)
        {
            try
            {
                var alunoId = _alunoRepository.Add(model);

                return alunoId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public AlunoDTO? GetAlunoByNameCpf(AlunoInputModel model)
        {
            try
            {
                var aluno = _alunoRepository.GetByNameCpf(model.sNome, model.sCPF);

                if (aluno is null)
                {
                    return new AlunoDTO();
                }

                return new AlunoDTO(aluno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public AlunoDTO? GetById(int id)
        {
            try
            {
                var aluno = _alunoRepository.GetById(id);

                if (aluno is null)
                {
                    return new AlunoDTO();
                }

                return new AlunoDTO(aluno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<AlunoDTO?> GetAll()
        {
            try
            {
                var alunos = _alunoRepository.GetAll();

                if (alunos.Count == 0)
                {
                    return new List<AlunoDTO?>();
                }

                return alunos.Select(a => new AlunoDTO(a)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public AlunoDTO? Update(AlunoInputModel model, int id)
        {
            try
            {
                var aluno = _alunoRepository.Update(model, id);

                if (aluno is null)
                {
                    return null;
                }

                return new AlunoDTO(aluno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _alunoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
