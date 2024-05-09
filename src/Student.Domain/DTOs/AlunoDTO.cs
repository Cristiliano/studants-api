using Student.Domain.Entities;

namespace Student.Domain.DTOs
{
    public class AlunoDTO : AlunoEntity
    {
        public AlunoDTO() { }
        public AlunoDTO(AlunoEntity aluno) 
        {
            iCodAluno = aluno.iCodAluno;
            sNome = aluno.sNome;
            dNascimento = aluno.dNascimento;
            sCPF = aluno.sCPF;
            sEndereco = aluno.sEndereco;
            sCelular = aluno.sCelular;  
        }
    }
}
