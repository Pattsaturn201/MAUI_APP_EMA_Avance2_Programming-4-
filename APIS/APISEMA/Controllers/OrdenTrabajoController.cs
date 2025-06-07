using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly OrdenTrabajoRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<OrdenTrabajo>> Get()
        {
            return _repo.ObtenerOrdenes();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<OrdenTrabajo> Get(int id)
        {
            var orden = _repo.ObtenerPorId(id);
            if (orden == null)
                return NotFound();
            return orden;
        }

        // POST
        [HttpPost]
        public ActionResult<OrdenTrabajo> Post([FromBody] OrdenTrabajo orden)
        {
            // Validar estado si es string, o convertir si usas enum
            if (!Enum.IsDefined(typeof(EstadoDeOrden), orden.Estado))
                return BadRequest("El estado de la orden no es válido.");

            var nueva = _repo.Add(orden);
            return CreatedAtAction(nameof(Get), new { id = nueva.Id }, nueva);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrdenTrabajo orden)
        {
            if (id != orden.Id)
                return BadRequest("El ID no coincide.");

            if (!Enum.IsDefined(typeof(EstadoDeOrden), orden.Estado))
                return BadRequest("El estado de la orden no es válido.");

            var actualizado = _repo.Update(orden);
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
