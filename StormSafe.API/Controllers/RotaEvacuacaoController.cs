using Microsoft.AspNetCore.Mvc;
using StormSafe.API.DTO.Request;
using StormSafe.API.DTO.Response;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Repositories;

namespace StormSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RotaEvacuacaoController : ControllerBase
    {
        private readonly RotaEvacuacaoRepository _repo;
        public RotaEvacuacaoController(RotaEvacuacaoRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IEnumerable<RotaEvacuacaoResponse>> GetAll()
        {
            var lista = await _repo.ListarAsync();
            return lista.Select(r => new RotaEvacuacaoResponse
            {
                Id = r.Id,
                Origem = r.Origem,
                Destino = r.Destino,
                RegiaoCritica = r.RegiaoCritica
            });
        }

        [HttpPost]
        public async Task<ActionResult<RotaEvacuacaoResponse>> Post(RotaEvacuacaoRequest dto)
        {
            var novo = new RotaEvacuacao
            {
                Origem = dto.Origem,
                Destino = dto.Destino,
                RegiaoCritica = dto.RegiaoCritica
            };
            var criado = await _repo.CriarAsync(novo);
            return CreatedAtAction(nameof(Post), new { id = criado.Id }, new RotaEvacuacaoResponse
            {
                Id = criado.Id,
                Origem = criado.Origem,
                Destino = criado.Destino,
                RegiaoCritica = criado.RegiaoCritica
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
