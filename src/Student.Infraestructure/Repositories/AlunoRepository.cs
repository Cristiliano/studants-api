using Microsoft.IdentityModel.Tokens;
using Student.Application.Interfaces;
using Student.Application.Models.InputModels;
using Student.Domain.Entities;

namespace Student.Infraestructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private List<AlunoEntity> alunoEntities = new List<AlunoEntity>()
        {
            new AlunoEntity()
            {
                iCodAluno = 1,
                dNascimento = DateTime.UtcNow,
                sCelular = "123",
                sCPF = "1234",
                sEndereco = "casa",
                sNome = "juao"
            }
        };

        public AlunoRepository() { }

        public int Add(AlunoInputModel model)
        {
            var rand = new Random();
            int ID = rand.Next(1, 1000);
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

        public AlunoEntity? GetByNameCpf(string? name, string? cpf) 
        {
            if(name.IsNullOrEmpty() && cpf.IsNullOrEmpty())
            {
                return null;
            }
            return alunoEntities.Find(a => a.sNome == name && a.sCPF == cpf);
        }
        
        public AlunoEntity? GetById(int id) 
        {
            return alunoEntities.Find(a => a.iCodAluno == id);
        }
        
        public List<AlunoEntity?> GetAll() 
        {
            return alunoEntities;
        }

        public AlunoEntity? Update(AlunoInputModel aluno, int id)
        {
            var alunoFind = GetById(id);
            
            if (alunoFind is null)
            {
                return null;
            } 

            alunoFind = new AlunoEntity
            {
                sNome = aluno.sNome,
                sCPF = aluno.sCPF,
                dNascimento = aluno.dNascimento,
                sCelular = aluno.sCelular,
                sEndereco = aluno.sEndereco,
            };

            return alunoFind;
        }

        public bool Delete(int id)
        {
            var alunoFind = GetById(id);

            if (alunoFind is null)
            {
                return false;
            }

            alunoEntities.Remove(alunoFind);

            return true;
        }
    }
}
