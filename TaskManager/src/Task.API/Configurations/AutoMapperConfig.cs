using AutoMapper;
using TaskManager.API.ViewModels;
using TaskManager.Business.Models;

namespace TaskManager.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
        }
    }
}
