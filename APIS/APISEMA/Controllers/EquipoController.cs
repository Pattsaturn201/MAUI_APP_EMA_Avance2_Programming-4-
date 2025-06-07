using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoController : ControllerBase
    {
        private readonly EquipoRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<Equipo>> Get()
        {
            return _repo.ObtenerEquipos();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Equipo> Get(int id)
        {
            var equipo = _repo.ObtenerPorId(id);
            if (equipo == null)
                return NotFound();
            return equipo;
        }

        // POST
        [HttpPost]
        public ActionResult<Equipo> Post([FromBody] Equipo equipo)
        {
            var nuevo = _repo.Add(equipo);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Equipo equipo)
        {
            if (id != equipo.Id)
                return BadRequest("El ID no coincide.");

            var actualizado = _repo.Update(equipo);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _repo.Delete(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
