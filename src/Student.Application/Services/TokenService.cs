using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private static byte[] KEY = [];

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            KEY = Encoding.ASCII.GetBytes(_configuration.GetSection("KEY").Value);
        }

        public object GenerateTokenUser(int iCodAluno)
        {
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("iCodAluno", iCodAluno.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KEY), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenConfig);

            var tokenStr = tokenHandler.WriteToken(token);

            return new { tokenStr };
        }

        public object GenerateTokenDefault()
        {
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KEY), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenConfig);

            var tokenStr = tokenHandler.WriteToken(token);

            return new { tokenStr };
        }
    }
}
