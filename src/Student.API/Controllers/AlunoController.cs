using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Models.InputModels;
using Student.Application.Services;
using Student.Domain.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status409Conflict)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        [SwaggerOperation("cria um objeto aluno")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] AlunoInputModel aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddAluno(aluno);

            return Ok(result);
        }

        [HttpGet("get_all")]
        [SwaggerOperation("recupera a lista de objetos aluno")]
        [ProducesResponseType(typeof(IEnumerable<List<AlunoDTO?>>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("get_by_id/{id}")]
        [SwaggerOperation("recupera o objeto aluno com base no iCodAluno")]
        [ProducesResponseType(typeof(IEnumerable<AlunoDTO?>), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.GetById(id);

            return Ok(result);
        }

        [HttpPatch("update/{id}")]
        [SwaggerOperation("atualiza os dados do aluno passado, com base no iCodAluno")]
        [ProducesResponseType(typeof(IEnumerable<AlunoDTO?>), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] AlunoInputModel aluno, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.Update(aluno, id);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation("remove o aluno correspondente ao iCodAluno passado")]
        [ProducesResponseType(typeof(IEnumerable<bool>), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.Delete(id);

            return Ok(result);
        }

    }
}
