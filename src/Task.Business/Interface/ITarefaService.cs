using TaskManager.Business.Models;

namespace TaskManager.Business.Interface
{
    public interface ITarefaService : IDisposable
    {
        Task<List<Tarefa>> ObterTodos();
        Task<Tarefa> ObterPorId(Guid id);
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(Guid id);
    }
}
