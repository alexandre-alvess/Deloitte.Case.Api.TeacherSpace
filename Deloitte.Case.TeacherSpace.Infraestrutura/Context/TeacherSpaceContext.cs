using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Context
{
    /// <summary>
    /// Define a classe <see cref="TeacherSpaceContext"/>.
    /// </summary>
    public class TeacherSpaceContext : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Boletim> Boletins { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<AlunoTurma> AlunoTurmas { get; set; }

        public TeacherSpaceContext()
        {
        }

        public TeacherSpaceContext(DbContextOptions<TeacherSpaceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new AlunoMap().Configure(builder.Entity<Aluno>());
            new BoletimMap().Configure(builder.Entity<Boletim>());
            new DisciplinaMap().Configure(builder.Entity<Disciplina>());
            new PessoaMap().Configure(builder.Entity<Pessoa>());
            new ProfessorMap().Configure(builder.Entity<Professor>());
            new TurmaMap().Configure(builder.Entity<Turma>());
            new UsuarioMap().Configure(builder.Entity<Usuario>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                var configuracao = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, false)
                    .Build();

                optionsBuilder.UseSqlServer(configuracao.GetConnectionString("DefaultConnection"), a => a.EnableRetryOnFailure(5, new TimeSpan(0, 0, 30), null));
            }
        }
    }
}
