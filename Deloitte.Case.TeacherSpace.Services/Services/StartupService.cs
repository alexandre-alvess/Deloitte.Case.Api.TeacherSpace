﻿using AutoMapper;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Mapeamentos;
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
            InicializeMapeamentos(services);
        }

        public static void InicializeServicos(IServiceCollection services)
        {
            services.AddScoped<IAlunoServico, AlunoServico>();
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

        public static void InicializeMapeamentos(IServiceCollection services)
        {
            var configuracaoMapeamentos = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                AutoMapeamentos.Inicialize(cfg);
            }).CreateMapper();

            services.AddSingleton(configuracaoMapeamentos);
        }
    }
}