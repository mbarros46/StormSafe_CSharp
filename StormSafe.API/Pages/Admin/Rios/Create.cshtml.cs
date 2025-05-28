using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StormSafe.API.Infrastructure.Persistence;
using StormSafe.API.Infrastructure.Contexts;

public class RiosCreateModel : PageModel
{
    private readonly StormSafeDbContext _context;
    public RiosCreateModel(StormSafeDbContext context) => _context = context;

    [BindProperty]
    public Rio Rio { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Rios.Add(Rio);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
