using System.ComponentModel.DataAnnotations;

namespace SelectionMBM.VagaAPI.ViewModel
{
    public class CandidatosViewModel
    {
        public Guid? IdVaga { get; set; }

        [Required(ErrorMessage = "Por favor, informe o titulo da vaga.")]
        public string? TituloVaga { get; set; }

        public Guid? IdCandidato { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do candidato.")]

        public string? Nome { get; set; }

        public char? StatusDoProcesso { get; set; }
    }
}
