using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Models.Requests;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
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
            cfg.CreateMap<AlunoModel, Aluno>().ReverseMap();
            cfg.CreateMap<Aluno, Pessoa>().ReverseMap();
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

        }

        private static void CriarMapeamentoTurma(IMapperConfigurationExpression cfg)
        {

        }

        private static void CriarMapeamentoUsuario(IMapperConfigurationExpression cfg)
        {

        }
    }
}
