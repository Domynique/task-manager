using TaskManager.Business.Models;

namespace TaskManager.Business.Interface
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefa(Guid id);
    }
}
