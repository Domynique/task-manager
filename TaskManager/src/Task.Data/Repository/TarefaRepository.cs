using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface;
using TaskManager.Business.Models;
using TaskManager.Data.Context;

namespace TaskManager.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(MeuDbContext db) : base(db)
        {

        }
        public async Task<Tarefa> ObterTarefa(Guid id)
        {
            return await Db.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
