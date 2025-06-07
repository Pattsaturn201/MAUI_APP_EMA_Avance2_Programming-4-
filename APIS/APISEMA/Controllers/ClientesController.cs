using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<Clientes>> Get()
        {
            return _repo.ObtenerClientes();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Clientes> Get(int id)
        {
            var cliente = _repo.ObtenerporId(id);
            if (cliente == null)
                return NotFound();
            return cliente;
        }

        // POST
        [HttpPost]
        public ActionResult<Clientes> Post([FromBody] Clientes cliente)
        {
            // Validar métodos de pago
            if (cliente.MetodosDePago.Any(m => !MetodosDePago.Lista.Contains(m)))
                return BadRequest("Uno o más métodos de pago no son válidos.");

            var nuevo = _repo.Add(cliente);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Clientes cliente)
        {
            if (id != cliente.Id)
                return BadRequest("El ID no coincide.");

            if (cliente.MetodosDePago.Any(m => !MetodosDePago.Lista.Contains(m)))
                return BadRequest("Uno o más métodos de pago no son válidos.");

            var actualizado = _repo.Update(cliente);
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
