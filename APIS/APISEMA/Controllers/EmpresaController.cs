using Microsoft.AspNetCore.Mvc;
using APISEMA.Models;
using APISEMA.Repositories;

namespace APISEMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaRepository _repo = new();

        // GET
        [HttpGet]
        public ActionResult<List<Empresa>> Get()
        {
            return _repo.ObtenerEmpresas();
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Empresa> Get(int id)
        {
            var empresa = _repo.ObtenerPorId(id);
            if (empresa == null)
                return NotFound();
            return empresa;
        }

        // POST
        [HttpPost]
        public ActionResult<Empresa> Post([FromBody] Empresa empresa)
        {
            var nueva = _repo.Add(empresa);
            return CreatedAtAction(nameof(Get), new { id = nueva.Id }, nueva);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empresa empresa)
        {
            if (id != empresa.Id)
                return BadRequest("El ID no coincide.");

            var actualizado = _repo.Update(empresa);
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
