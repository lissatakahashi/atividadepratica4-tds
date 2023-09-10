using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public int CursoComMaisAlunos { get; set; }


        public void OnGet()
        {
            TotalDeCursos = _context.Cursos!.Count();
            TotalDeAlunos = _context.Alunos!.Count();
        }
    }
}