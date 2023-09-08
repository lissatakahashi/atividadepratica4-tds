using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Alunos
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set; } = new();

        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            try {
                _context.Add(AlunoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Alunos/Create");   
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}