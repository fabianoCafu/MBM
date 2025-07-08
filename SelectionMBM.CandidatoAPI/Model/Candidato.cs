using System.ComponentModel.DataAnnotations;

namespace SelectionMBM.CandidatoAPI.Model
{
    public class Candidato
    {
        public Guid Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public char Sexo { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido (formato esperado: (99) 99999-9999)")]
        public string? Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
