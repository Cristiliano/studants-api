using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Infraestructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private List<AlunoEntity> alunoEntities = new List<AlunoEntity>();
        private int ID = 0;

        public AlunoRepository() { }

        public int Add(AlunoInputModel model)
        {
            ID++;
            var entity = new AlunoEntity
            {
                iCodAluno = ID,
                sNome = model.sNome,
                dNascimento = model.dNascimento,
                sCPF = model.sCPF,
                sEndereco = model.sEndereco,    
                sCelular = model.sCelular
            };

            alunoEntities.Add(entity);
            return entity.iCodAluno;
        }
    }
}
