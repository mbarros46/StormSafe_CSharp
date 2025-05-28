using Microsoft.AspNetCore.Mvc;
using StormSafe.API.DTO.Request;
using StormSafe.API.DTO.Response;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Repositories;

namespace StormSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RioController : ControllerBase
    {
        private readonly RioRepository _repo;

        public RioController(RioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RioResponse>>> GetAll()
        {
            var rios = await _repo.ListarAsync();
            return Ok(rios.Select(r => new RioResponse { Id = r.Id, Nome = r.Nome }));
        }

        [HttpPost]
        public async Task<ActionResult<RioResponse>> Post([FromBody] RioRequest dto)
        {
            var novo = new Rio { Nome = dto.Nome };
            var criado = await _repo.CriarAsync(novo);
            return CreatedAtAction(nameof(Post), new { id = criado.Id }, new RioResponse { Id = criado.Id, Nome = criado.Nome });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _repo.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}
