﻿// <auto-generated />
using System;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Migrations
{
    [DbContext(typeof(TeacherSpaceContext))]
    [Migration("20230501191427_AlunoTurma-Add")]
    partial class AlunoTurmaAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.AlunoTurma", b =>
                {
                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AlunoId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("AlunoTurmas");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Boletim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Boletins", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("DisciplinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turmas", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Professores", (string)null);
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", "PessoaId")
                        .IsRequired()
                        .HasConstraintName("FK_Aluno_Pessoa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.AlunoTurma", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", "Aluno")
                        .WithMany("AlunoTurmas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Turma", "Turma")
                        .WithMany("AlunoTurmas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Boletim", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Turma", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entities.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("Deloitte.Case.TeacherSpace.Domain.Entidades.Usuario", "PessoaId")
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Pessoa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entities.Professor", b =>
                {
                    b.HasOne("Deloitte.Case.TeacherSpace.Domain.Entidades.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("Deloitte.Case.TeacherSpace.Domain.Entities.Professor", "PessoaId")
                        .IsRequired()
                        .HasConstraintName("FK_Professor_Pessoa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Aluno", b =>
                {
                    b.Navigation("AlunoTurmas");

                    b.Navigation("Boletins");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entidades.Turma", b =>
                {
                    b.Navigation("AlunoTurmas");
                });

            modelBuilder.Entity("Deloitte.Case.TeacherSpace.Domain.Entities.Professor", b =>
                {
                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}
