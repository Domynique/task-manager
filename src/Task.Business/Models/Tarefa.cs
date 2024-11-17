using TaskManager.Business.Models;

namespace TaskManager.Business.Models
{
    public class Tarefa : Entity
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public Status Status { get; set; }

        public Tarefa()
        {
            
        }

        public Tarefa(string titulo)
        {
            Titulo = titulo;
            DataDeCriacao = DateTime.Now;
            Status = Status.Pendente;
            
        }

    }
}
