using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

public class SensoresIndexModel : PageModel
{
    private readonly StormSafeDbContext _context;
    public SensoresIndexModel(StormSafeDbContext context) => _context = context;

    public List<Sensor> Sensores { get; set; } = new();

    public async Task OnGetAsync() =>
        Sensores = await _context.Sensores.Include(s => s.Rio).ToListAsync();

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        if (sensor != null)
        {
            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}
