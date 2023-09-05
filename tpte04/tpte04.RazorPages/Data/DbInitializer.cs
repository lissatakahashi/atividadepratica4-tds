using tpte03.RazorPages.Models;

namespace tpte03.RazorPages.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) {
            if (context.Feedbacks!.Any()) {
                return;
            }

            var feedbacks = new FeedbackModel[] {
                new FeedbackModel{
                    NomeCliente = "Alícia Campos",
                    EmailCliente = "aliciacampos@gmail.com",
                    DataFeedback = DateTime.Parse("2023-09-01"),
                    Comentario = "Ótimo produto.",
                    Avaliacao = 5
                }
            };

            context.AddRange(feedbacks);
            context.SaveChanges();
        }
    }
}