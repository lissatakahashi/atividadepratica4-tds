using tpte04.RazorPages.Model;

namespace tpte04.RazorPages.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) 
        {
            if (!context.Cursos!.Any()) 
            {
                var cursos = new CursoModel[] {
                    new CursoModel {
                        NomeCurso = "Java",
                        Descricao = "Curso de Java do básico ao avançado",
                        DataInicio = DateTime.Parse("2024-02-12"),
                        DataTermino = DateTime.Parse("2024-11-30")
                    },
                };
                context.AddRange(cursos);
            }

            if(!context.Alunos!.Any())
            {
                var alunos = new AlunoModel[] {
                    new AlunoModel {
                        NomeAluno = "Alícia Santos",
                        Email = "aliciasantos@gmail.com",
                        DataInscricao = DateTime.Parse("2024-02-10")
                    },
                };
                context.AddRange(alunos);
            }

            context.SaveChanges();
        }
    }
}