using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public CursoModel CursoModel { get; set;  } = new();
        
        public Details(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null) {
                return NotFound();
            }   

            var cursoModel =
             await _context.Cursos.Include(e=>e.Alunos) .FirstOrDefaultAsync(e => e.IdCurso == id);

             if (cursoModel == null) {
                return NotFound();
             }

             CursoModel = cursoModel;
            
            return Page();
        }

    }
}