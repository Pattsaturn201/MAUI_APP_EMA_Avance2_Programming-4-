using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<Empleados>> Get()
        {
            return _repo.ObtenerEmpleados();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Empleados> Get(int id)
        {
            var empleado = _repo.ObtenerPorId(id);
            if (empleado == null)
                return NotFound();
            return empleado;
        }

        // POST
        [HttpPost]
        public ActionResult<Empleados> Post([FromBody] Empleados empleado)
        {
            var nuevo = _repo.Add(empleado);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empleados empleado)
        {
            if (id != empleado.Id)
                return BadRequest("El ID no coincide.");

            var actualizado = _repo.Update(empleado);
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
