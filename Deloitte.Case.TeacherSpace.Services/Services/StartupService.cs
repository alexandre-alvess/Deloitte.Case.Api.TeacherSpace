using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="StartupService"/>.
    /// </summary>
    public static class StartupService
    {
        public static void Inicialize(IServiceCollection services)
        {
            InicializeRepositorios(services);
            InicializeServicos(services);
        }

        public static void InicializeServicos(IServiceCollection services)
        {
            services.AddScoped<IAlunoServico, AlunoServico>();
            services.AddScoped<IProfessorServico, ProfessorServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IDisciplinaServico, DisciplinaServico>();
        }

        public static void InicializeRepositorios(IServiceCollection services)
        {
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IBoletimRepositorio, BoletimRepositorio>();
            services.AddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
