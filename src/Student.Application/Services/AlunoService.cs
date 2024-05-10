using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.DTOs;

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

                if (aluno == null)
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
    }
}
