using apiwithpomelo.Repositories;
using apiwithpomelo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace apiwithpomelo
{
    internal static class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            // AddScoped    -> Para cada Requisição é instanciado um novo objeto compartilhado por todas Classes 
            // AddSingleton -> Para cada Requisição é utilizada uma única instância do objeto
            // AddTransient -> Para cada Requisição é instanciado um novo objeto para cada Classe

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}