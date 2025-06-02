using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormSafe.Infrastructure.Contexts;
using StormSafe.Infrastructure.Persistence;

namespace StormSafe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RioController : ControllerBase
    {
        private readonly StormSafeDbContext _context;

        public RioController(StormSafeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rio>>> GetRios()
        {
            return await _context.Rios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Rio>> PostRio(Rio rio)
        {
            _context.Rios.Add(rio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRios), new { id = rio.RioId }, rio);
        }
    }
}