using Microsoft.AspNetCore.Mvc;
using StormSafe.API.DTO.Request;
using StormSafe.API.DTO.Response;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Repositories;

namespace StormSafe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorRepository _repo;

        public SensorController(SensorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorResponse>>> GetAll()
        {
            var sensores = await _repo.ListarAsync();
            return Ok(sensores.Select(s => new SensorResponse {
                Id = s.Id,
                Tipo = s.Tipo,
                Valor = s.Valor,
                DataLeitura = s.DataLeitura,
                RioId = s.RioId
            }));
        }

        [HttpPost]
        public async Task<ActionResult<SensorResponse>> Post([FromBody] SensorRequest dto)
        {
            var novo = new Sensor {
                Tipo = dto.Tipo,
                Valor = dto.Valor,
                DataLeitura = dto.DataLeitura,
                RioId = dto.RioId
            };
            var criado = await _repo.CriarAsync(novo);
            return CreatedAtAction(nameof(Post), new { id = criado.Id }, new SensorResponse {
                Id = criado.Id,
                Tipo = criado.Tipo,
                Valor = criado.Valor,
                DataLeitura = criado.DataLeitura,
                RioId = criado.RioId
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _repo.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}
