using TaskManager.Business.Interface;
using TaskManager.Business.Notificacoes;
using TaskManager.Business.Services;
using TaskManager.Data.Context;
using TaskManager.Data.Repository;

namespace TaskManager.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
