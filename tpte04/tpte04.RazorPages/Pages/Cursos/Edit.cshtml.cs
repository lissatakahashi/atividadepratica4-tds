using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public CursoModel CursoModel { get; set; } = new();

        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null) {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FirstOrDefaultAsync(curso => curso.IdCurso == id);

            if (cursoModel == null) {
                return NotFound();
            }

            CursoModel = cursoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            var cursoToUpdate = await _context.Cursos!.FindAsync(id);

            if (cursoToUpdate == null) {
                return NotFound();
            }

            cursoToUpdate.NomeCurso = CursoModel.NomeCurso;
            cursoToUpdate.Descricao = CursoModel.Descricao;
            cursoToUpdate.DataInicio = CursoModel.DataInicio;
            cursoToUpdate.DataTermino = CursoModel.DataTermino;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}