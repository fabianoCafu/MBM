using System.ComponentModel.DataAnnotations;

namespace SelectionMBM.VagaAPI.Model
{
    public class Vaga
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o titulo da vaga.")]
        public string? TituloVaga { get; set; }

        [Required(ErrorMessage = "Por favor, informe a localização da vaga.")]
        public string? LocalVaga { get; set; }

        [Required(ErrorMessage = "Por favor, informe a modalida de trabalho da vaga.")]
        public string? Modalidade { get; set; }

        public string? Organizacao { get; set; }

        public string? Descricao { get; set; }

        public Guid? IdCandidato { get; set; }

        public string? Nome { get; set; }
    }
}
