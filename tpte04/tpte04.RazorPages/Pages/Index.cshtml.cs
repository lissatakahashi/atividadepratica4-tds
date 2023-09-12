using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpte04.RazorPages.Data;

namespace tpte04.RazorPages.Pages
{
    public class Index : PageModel

    {
    private readonly AppDbContext _context;
        public Index(AppDbContext context)
        {
            _context = context;
        }

        public int TotalDeCursos { get; set; }
        public int TotalDeAlunos { get; set; }
        public string? CursoComMaisInscricoes { get; set; }

        public void OnGet()
        {
            TotalDeCursos = _context.Cursos!.Count();
            TotalDeAlunos = _context.Alunos!.Count();

            var cursoComMaisInscricoes = _context.Cursos!.Include(c => c.Alunos).OrderByDescending(c => c.Alunos!.Count).FirstOrDefault();

            CursoComMaisInscricoes = cursoComMaisInscricoes != null ? cursoComMaisInscricoes.NomeCurso : "Nenhum curso encontrado";
        }
    }
}