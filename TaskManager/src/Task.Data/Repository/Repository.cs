using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface;
using TaskManager.Business.Models;
using TaskManager.Data.Context;

namespace TaskManager.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity , new()
    {
        private readonly MeuDbContext Db;
        private readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChange();
        }

        public async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChange();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChange();

        }

        public Task<int> SaveChange()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
