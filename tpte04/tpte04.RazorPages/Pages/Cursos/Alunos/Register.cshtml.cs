using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Cursos.Alunos
{
    public class Register : PageModel
    {
        private readonly AppDbContext _context;
        public List<CursoModel>? CursoList { get; set; }
        public List<AlunoModel>? AlunoList { get; set; }

        public Register(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CursoList = await _context.Cursos!.ToListAsync();
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int curso, int aluno)
        {
            var selectedCurso = await _context.Cursos!.Include(e => e.Alunos).FirstOrDefaultAsync(e => e.IdCurso == curso);
            var selectedAluno = await _context.Alunos!.FindAsync(aluno);

            if (selectedCurso == null || selectedAluno == null)
            {
                return NotFound();
            }

            selectedCurso.Alunos!.Add(selectedAluno);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}