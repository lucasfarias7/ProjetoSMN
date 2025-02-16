using Services.Services.ClasseConcreta;
using Services.Services.Interfaces;
using SMNPastel.Providers;
using SMNPastel.Repository.ClasseConcreta;
using SMNPastel.Repository.interfaces;
using SMNPastel.Services.ClasseConcreta;
using SMNPastel.Services.Interfaces;

namespace SMNPastel.Configuration
{
    public static class ConfigurationDependencyInject
    {
        public static void RegisterServices(this IServiceCollection services, string? sendGridApiKey)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPasswordProvider, PasswordProvider>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddSingleton<IEmailService>(provider => new EmailService(sendGridApiKey!));            
            //services.AddTransient
        }

        public static void RegisterRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
        }
    }
}
