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
    public class MateriaController(IMateriaService service) : ControllerBase
    {
        private readonly IMateriaService _service = service;

        [HttpPost("create")]
        [SwaggerOperation("cria um objeto materia")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] MateriaInputModel materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddMateria(materia);

            return Ok(result);
        }

        [HttpGet("get_all")]
        [SwaggerOperation("recupera a lista de objetos materia")]
        [ProducesResponseType(typeof(IEnumerable<List<MateriaDTO?>>), StatusCodes.Status200OK)]
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
        [SwaggerOperation("recupera o objeto aluno com base no iCodMateria")]
        [ProducesResponseType(typeof(IEnumerable<MateriaDTO?>), StatusCodes.Status200OK)]
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
        [SwaggerOperation("atualiza os dados da materia passada, com base no iCodMateria")]
        [ProducesResponseType(typeof(IEnumerable<MateriaDTO?>), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] MateriaInputModel materia, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.Update(materia, id);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation("remove a materia correspondente ao iCodMateria passado")]
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
