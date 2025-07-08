using System.ComponentModel.DataAnnotations;

namespace SelectionMBM.Web.Models
{
    public class CandidatoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do candidato.")]
        public string? Nome { get; set; }

        public char Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do candidato.")]
        [Phone]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido (formato esperado: (99) 99999-9999)")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Por favor, informe o e-mail do candidato.")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
