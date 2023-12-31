using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;
using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Pages.Alunos
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set; } = new();

        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(aluno => aluno.IdAluno == id);

            if (alunoModel == null) {
                return NotFound();
            }

            AlunoModel = alunoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            var alunoToUpdate = await _context.Alunos!.FindAsync(id);

            if (alunoToUpdate == null) {
                return NotFound();
            }

            alunoToUpdate.NomeAluno = AlunoModel.NomeAluno;
            alunoToUpdate.Email = AlunoModel.Email;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Alunos/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}