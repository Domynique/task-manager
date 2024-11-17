using System.Collections.Generic;
using TaskManager.Business.Interface;
using TaskManager.Business.Models;
using TaskManager.Business.Models.Validation;

namespace TaskManager.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository, INotificador notificador) 
            : base(notificador) 
        {
            _tarefaRepository = tarefaRepository;
        }


        public virtual async Task<List<Tarefa>> ObterTodos()
        {
            return await _tarefaRepository.ObterTodos();
        }

        public virtual async Task<Tarefa> ObterPorId(Guid id)
        {
            return await _tarefaRepository.ObterPorId(id);
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            await _tarefaRepository.Adicionar(tarefa);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            if (ExecutarValidacao(new TarefaValidation(), tarefa)) return;
  
            await _tarefaRepository.Atualizar(tarefa);
        }
        public async Task Remover(Guid id)
        {
            await _tarefaRepository.Remover(id);
        }
        
        public void Dispose()
        {
            _tarefaRepository?.Dispose();
        }

    }
}
