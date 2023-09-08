using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public CursoModel CursoModel { get; set; } = new();

        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            try {
                _context.Add(CursoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Create");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}