using Microsoft.AspNetCore.Mvc.RazorPages;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RiosIndexModel : PageModel
{
    private readonly StormSafeDbContext _context;
    public RiosIndexModel(StormSafeDbContext context) => _context = context;

    public List<Rio> Rios { get; set; } = new();

    public async Task OnGetAsync() => Rios = await _context.Rios.ToListAsync();

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var rio = await _context.Rios.FindAsync(id);
        if (rio != null)
        {
            _context.Rios.Remove(rio);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}
