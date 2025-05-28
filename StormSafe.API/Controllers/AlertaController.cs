using Microsoft.AspNetCore.Mvc;
using StormSafe.API.DTO.Request;
using StormSafe.API.DTO.Response;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Repositories;

namespace StormSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaRepository _repo;
        public AlertaController(AlertaRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IEnumerable<AlertaResponse>> GetAll()
        {
            var lista = await _repo.ListarAsync();
            return lista.Select(a => new AlertaResponse
            {
                Id = a.Id,
                Mensagem = a.Mensagem,
                NivelRisco = a.NivelRisco,
                CriadoEm = a.CriadoEm
            });
        }

        [HttpPost]
        public async Task<ActionResult<AlertaResponse>> Post(AlertaRequest dto)
        {
            var novo = new Alerta { Mensagem = dto.Mensagem, NivelRisco = dto.NivelRisco };
            var criado = await _repo.CriarAsync(novo);
            return CreatedAtAction(nameof(Post), new { id = criado.Id }, new AlertaResponse
            {
                Id = criado.Id,
                Mensagem = criado.Mensagem,
                NivelRisco = criado.NivelRisco,
                CriadoEm = criado.CriadoEm
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repo.RemoverAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
