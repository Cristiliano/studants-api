namespace Student.Application.Services
{
    public interface ITokenService
    {
        object GenerateTokenDefault();
        object GenerateTokenUser(int iCodAluno);
    }
}