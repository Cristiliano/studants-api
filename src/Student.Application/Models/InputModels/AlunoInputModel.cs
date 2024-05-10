namespace Student.Application.Models.InputModels
{
    public class AlunoInputModel
    {
        public AlunoInputModel(string? sNome, DateTime? dNascimento, string? sCPF, string? sEndereco, string? sCelular)
        {
            this.sNome = sNome;
            this.dNascimento = dNascimento;
            this.sCPF = sCPF;
            this.sEndereco = sEndereco;
            this.sCelular = sCelular;
        }

        public AlunoInputModel(string? sNome, string? sCPF) 
        {
            this.sNome = sNome; 
            this.sCPF = sCPF;
        }

        public AlunoInputModel() { }

        public string? sNome { get; set; }
        public DateTime? dNascimento { get; set; }
        public string? sCPF { get; set; }
        public string? sEndereco { get; set; }
        public string? sCelular { get; set; }
    }
}
