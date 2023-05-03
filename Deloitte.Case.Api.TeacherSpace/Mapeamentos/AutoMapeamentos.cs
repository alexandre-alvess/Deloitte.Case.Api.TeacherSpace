using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.Api.TeacherSpace.Models.Responses;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Services.Models;

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
            CriarMapeamentoProfessor(cfg);
            CriarMapeamentoTurma(cfg);
            CriarMapeamentoUsuario(cfg);
            CriarMapeamentoAutenticacao(cfg);
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
            cfg.CreateMap<BoletimRequest, BoletimModel>().ReverseMap();
            cfg.CreateMap<BoletimResponse, BoletimModel>().ReverseMap();
            cfg.CreateMap<BoletimModel, Boletim>().ReverseMap();
            cfg.CreateMap<TurmaBoletimModel, TurmaBoletimResponse>().ReverseMap();
            cfg.CreateMap<AlunoBoletimModel, AlunoBoletimResponse>().ReverseMap();
        }

        private static void CriarMapeamentoDisciplina(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DisciplinaRequest, DisciplinaModel>().ReverseMap();
            cfg.CreateMap<DisciplinaResponse, DisciplinaModel>().ReverseMap();
            cfg.CreateMap<DisciplinaModel, Disciplina>().ReverseMap();
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
            cfg.CreateMap<AlunoTurmaRequest, AlunoTurmaModel>().ReverseMap();
            cfg.CreateMap<AlunoTurmaResponse, AlunoTurmaModel>().ReverseMap();
            cfg.CreateMap<AlunoTurmaModel, AlunoTurma>().ReverseMap();

            cfg.CreateMap<TurmaRequest, TurmaModel>().ReverseMap();
            cfg.CreateMap<TurmaResponse, TurmaModel>().ReverseMap();
            cfg.CreateMap<Turma, TurmaModel>();

            cfg.CreateMap<TurmaModel, TurmaProfessorResponse>()
                .ForMember(x => x.Turma, y => y.MapFrom(z => z.Nome))
                .ForMember(x => x.TurmaId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProfessorId, y => y.MapFrom(z => z.ProfessorId))
                .ReverseMap();

            cfg.CreateMap<TurmaModel, Turma>()
                .ForMember(x => x.Professor, opt => opt.Ignore())
                .ForMember(x => x.Disciplina, opt => opt.Ignore());
        }

        private static void CriarMapeamentoUsuario(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UsuarioRequest, UsuarioModel>().ReverseMap();
            cfg.CreateMap<UsuarioResponse, UsuarioModel>().ReverseMap();
            
            cfg.CreateMap<Usuario, Pessoa>()
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Login))
                .ReverseMap();
            
            cfg.CreateMap<Usuario, UsuarioModel>()
                .ForMember(x => x.Nome, y => y.MapFrom(z => z.Pessoa != null ? z.Pessoa.Nome : string.Empty))
                .ReverseMap();
        }

        private static void CriarMapeamentoAutenticacao(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AutenticacaoRequest, AutenticacaoModel>().ReverseMap();
            cfg.CreateMap<AutenticacaoResponse, UsuarioAutenticacao>().ReverseMap();
        }
    }
}
