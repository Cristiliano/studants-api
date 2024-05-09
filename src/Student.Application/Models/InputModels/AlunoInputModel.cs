namespace Student.Application.Models.InputModels
{
    public class AlunoInputModel
    {
        public AlunoInputModel(string _sNome, DateTime _dNascimento, string _sCPF, string _sEndereco, string _sCelular)
        {
            _sNome = sNome;
            _dNascimento = dNascimento;
            _sCPF = sCPF;
            _sEndereco = sEndereco;
            _sCelular = sCelular;
        }

        public string sNome { get; set; }
        public DateTime dNascimento { get; set; }
        public string sCPF { get; set; }
        public string sEndereco { get; set; }
        public string sCelular { get; set; }
    }
}
