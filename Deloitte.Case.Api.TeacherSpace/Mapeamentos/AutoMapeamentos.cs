using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.Api.TeacherSpace.Models.Responses;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.Api.TeacherSpace.Mapeamentos
{
    /// <summary>
    /// Define a configuração dos mapeamentos da aplicação que serão inicializados.
    /// </summary>
    public static class AutoMapeamentos
    {
        /// <summary>
        /// Configuração dos mapeamentos da aplicação.
        /// </summary>
        public static void Inicialize(IMapperConfigurationExpression cfg)
        {
            CriarMapeamentoAluno(cfg);
            CriarMapeamentoBoletim(cfg);
            CriarMapeamentoDisciplina(cfg);
            CriarMapeamentoPessoa(cfg);
            CriarMapeamentoProfessor(cfg);
            CriarMapeamentoTurma(cfg);
            CriarMapeamentoUsuario(cfg);
        }

        private static void CriarMapeamentoAluno(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AlunoRequest, AlunoModel>().ReverseMap();
            cfg.CreateMap<AlunoResponse, AlunoModel>().ReverseMap();
            cfg.CreateMap<Aluno, Pessoa>().ReverseMap();

            cfg.CreateMap<Aluno, AlunoModel>()
                .ForMember(x => x.Nome, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.Nome : string.Empty))
                .ForMember(x => x.DataNascimento, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.DataNascimento : new DateTime()))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.Email : string.Empty))
                .ReverseMap();
        }

        private static void CriarMapeamentoBoletim(IMapperConfigurationExpression cfg)
        {

        }

        private static void CriarMapeamentoDisciplina(IMapperConfigurationExpression cfg)
        {

        }

        private static void CriarMapeamentoPessoa(IMapperConfigurationExpression cfg)
        {

        }

        private static void CriarMapeamentoProfessor(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ProfessorRequest, ProfessorModel>().ReverseMap();
            cfg.CreateMap<ProfessorResponse, ProfessorModel>().ReverseMap();
            cfg.CreateMap<Professor, Pessoa>().ReverseMap();

            cfg.CreateMap<Professor, ProfessorModel>()
                .ForMember(x => x.Nome, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.Nome : string.Empty))
                .ForMember(x => x.DataNascimento, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.DataNascimento : new DateTime()))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.Email : string.Empty))
                .ReverseMap();
        }

        private static void CriarMapeamentoTurma(IMapperConfigurationExpression cfg)
        {

        }

        private static void CriarMapeamentoUsuario(IMapperConfigurationExpression cfg)
        {

        }
    }
}
