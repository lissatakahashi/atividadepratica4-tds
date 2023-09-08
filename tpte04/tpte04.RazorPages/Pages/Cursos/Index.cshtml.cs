using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<CursoModel> CursoList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CursoList = await _context.Cursos!.ToListAsync();
            return Page();
        }
    }
}