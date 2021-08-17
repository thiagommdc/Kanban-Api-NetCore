using BancoDados.Interface;
using BancoDados.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace BancoDados
{
    public class Dependencias
    {
        public Dependencias(IServiceCollection services)
        {
            services.AddTransient<ITarefas, Tarefas>();
        }
    }
}