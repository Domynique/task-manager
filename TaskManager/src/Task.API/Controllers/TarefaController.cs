using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.ViewModels;
using TaskManager.Business.Interface;
using TaskManager.Business.Models;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : MainController
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaService tarefaService,
                                ITarefaRepository tarefaRepository,
                                INotificador notificador, 
                                IMapper mapper) : base(notificador)
        {
            _tarefaService = tarefaService;
            _tarefaRepository = tarefaRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TarefaViewModel>> ObterTodos()
        {
           return _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> ObterPorId(Guid id)
        {
            var tarefaViewModel = await ObterTarefa(id);

            if (tarefaViewModel == null) return NotFound();

            return tarefaViewModel;

        }

        [HttpPost]
        public async Task<ActionResult<TarefaViewModel>> Adicionar(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaViewModel));

            return CustomResponse(tarefaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> Atualizar(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (id != tarefaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo passado na query");
                return CustomResponse(tarefaViewModel);
            }

            var tarefaAtualizacao = await ObterTarefa(id);
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            tarefaAtualizacao.Titulo = tarefaViewModel.Titulo;
            tarefaAtualizacao.Descricao = tarefaViewModel.Descricao;
            tarefaAtualizacao.Status = tarefaViewModel.Status;
            tarefaAtualizacao.DataDeConclusao = tarefaViewModel.DataDeConclusao;

            await _tarefaService.Atualizar(_mapper.Map<Tarefa>(tarefaAtualizacao));
            
            return CustomResponse(tarefaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaViewModel>> Excluir(Guid id)
        {
            var terefaViewModel = await ObterTarefa(id);

            if (terefaViewModel == null) return NotFound();

            await _tarefaService.Remover(id);

            return CustomResponse(terefaViewModel); 
        }

        private async Task<TarefaViewModel> ObterTarefa(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterTarefa(id));
        }

    }
}
