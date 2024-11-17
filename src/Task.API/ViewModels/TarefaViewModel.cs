using System.ComponentModel.DataAnnotations;
using TaskManager.Business.Models;

namespace TaskManager.API.ViewModels
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Titulo { get; set; }

        [StringLength(1000, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeCriacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataDeConclusao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Status Status { get; set; }
    }
}
