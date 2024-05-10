using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Student.Application.Models.InputModels;
using Student.Application.Services;
using Student.Domain.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IConfiguration _configuration;
        private ITokenService _tokenService;

        public AuthController(IAlunoService alunoService = null, IConfiguration configuration = null)
        {
            _alunoService = alunoService;
            _configuration = configuration;
            _tokenService = new TokenService(_configuration);
        }

        [HttpPost]
        [SwaggerOperation("gera um token tomando por parametro o iCodAluno correspondente a chave (nome, cpf)")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        public IActionResult Auth(string? name, string? cpf)
        {
            if(!name.IsNullOrEmpty() && !cpf.IsNullOrEmpty())
            {
                var aluno = _alunoService.GetAlunoByNameCpf(new AlunoInputModel(name, cpf));

                var token = _tokenService.GenerateTokenUser(aluno.iCodAluno);

                return Ok(token);
            }

            return BadRequest("aluno Not Found");
        }
        
        [HttpGet]
        [SwaggerOperation("gera um token")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        public IActionResult Auth()
        {
            var token = _tokenService.GenerateTokenDefault();

            return Ok(token);
        }
    }
}
