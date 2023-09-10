using System.ComponentModel.DataAnnotations;

namespace tpte04.RazorPages.Model {
    public class AlunoModel {
        public int? IdAluno { get; set; }
        public string? NomeAluno { get; set; }
        public string? Email { get; set; }
        public DateTime? DataInscricao { get; set; }
    }
}