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
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public class NotaController(INotaService service) : ControllerBase
    {
        private readonly INotaService _service = service;

        [HttpPost("create")]
        [SwaggerOperation("cria um objeto nota")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] NotaInputModel nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddNota(nota);

            return Ok(result);
        }

        [HttpGet("get_all")]
        [SwaggerOperation("recupera a lista de objetos nota")]
        [ProducesResponseType(typeof(IEnumerable<List<NotaDTO?>>), StatusCodes.Status200OK)]
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
        [SwaggerOperation("recupera o objeto nota com base no iCodNota")]
        [ProducesResponseType(typeof(IEnumerable<NotaDTO?>), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.GetById(id);

            return Ok(result);
        }

        [HttpPatch("update/{id}")]
        [SwaggerOperation("atualiza os dados da nota passada, com base no iCodNota")]
        [ProducesResponseType(typeof(IEnumerable<NotaDTO?>), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] NotaInputModel nota, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.Update(nota, id);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation("remove a nota correspondente ao iCodNota passado")]
        [ProducesResponseType(typeof(IEnumerable<bool>), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int id)
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
