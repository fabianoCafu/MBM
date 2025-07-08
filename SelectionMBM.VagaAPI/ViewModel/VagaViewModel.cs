using System.ComponentModel.DataAnnotations;

namespace SelectionMBM.VagaAPI.ViewModel
{
    public class VagaViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string? TituloVaga { get; set; }

        [Required]
        public string? LocalVaga { get; set; }

        [Required]
        public string? Modalidade { get; set; }

        public string? Organizacao { get; set; }

        public string? Descricao { get; set; }
    }
}
