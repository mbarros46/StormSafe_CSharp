using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormSafe.Infrastructure.Contexts;
using StormSafe.Infrastructure.Persistence;

namespace StormSafe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly StormSafeDbContext _context;

        public SensorController(StormSafeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensores()
        {
            return await _context.Sensores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSensores), new { id = sensor.SensorId }, sensor);
        }
    }
}