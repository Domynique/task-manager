using FluentValidation;

namespace TaskManager.Business.Models.Validation
{
    public class TarefaValidation : AbstractValidator<Tarefa>
    {
        public TarefaValidation()
        {
            RuleFor(t => t.Titulo)
                    .NotEmpty().WithMessage("O título é obrigatório.")
                    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(t => t.Descricao)
                    .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(t => t.DataDeConclusao)
                    .Must((t, dataDeConclusao) => !dataDeConclusao.HasValue || dataDeConclusao.Value >= t.DataDeCriacao)
                    .WithMessage("Data de Conclusão não pode ser anterior à Data de Criação.");
        }
    }
}
