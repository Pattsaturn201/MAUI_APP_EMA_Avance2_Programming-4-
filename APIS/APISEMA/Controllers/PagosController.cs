using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly PagosRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<Pagos>> Get()
        {
            return _repo.ObtenerPagos();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Pagos> Get(int id)
        {
            var pago = _repo.ObtenerPorId(id);
            if (pago == null)
                return NotFound();
            return pago;
        }

        // POST
        [HttpPost]
        public ActionResult<Pagos> Post([FromBody] Pagos pago)
        {
            var nuevo = _repo.Add(pago);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pagos pago)
        {
            if (id != pago.Id)
                return BadRequest("El ID no coincide.");

            var actualizado = _repo.Update(pago);
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
