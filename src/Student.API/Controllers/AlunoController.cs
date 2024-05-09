using Microsoft.AspNetCore.Mvc;
using Student.Application.Models.InputModels;
using Student.Application.Services;
using Student.Domain.DTOs;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddAluno(new AlunoInputModel(aluno.sNome, aluno.dNascimento, aluno.sCPF, aluno.sEndereco, aluno.sCelular));

            return Ok(result);
        }
    }
}
