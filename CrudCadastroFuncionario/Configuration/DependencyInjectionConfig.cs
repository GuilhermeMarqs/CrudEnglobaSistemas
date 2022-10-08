using CrudCadastroFuncionario.Context;
using CrudCadastroFuncionario.Interfaces;
using CrudCadastroFuncionario.Repository;

namespace CrudCadastroFuncionario.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextDataBase>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            return services;
        }
    }
}
