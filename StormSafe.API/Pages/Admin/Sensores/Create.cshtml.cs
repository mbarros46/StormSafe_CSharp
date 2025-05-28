using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

public class SensoresCreateModel : PageModel
{
    private readonly StormSafeDbContext _context;
    public SensoresCreateModel(StormSafeDbContext context) => _context = context;

    [BindProperty]
    public Sensor Sensor { get; set; } = new();
    public SelectList Rios { get; set; }

    public async Task OnGetAsync()
    {
        var rios = await _context.Rios.ToListAsync();
        Rios = new SelectList(rios, "Id", "Nome");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Sensores.Add(Sensor);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
