using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public CursoModel CursoModel { get; set; } = new();

        public Delete(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null) {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FirstOrDefaultAsync(feedback => feedback.IdCurso == id);

            if (cursoModel == null) {
                return NotFound();
            }

            CursoModel = cursoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            var feedbackToDelete = await _context.Cursos!.FindAsync(id);

            if (feedbackToDelete == null) {
                return NotFound();
            }

            try {
                _context.Cursos.Remove(feedbackToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}