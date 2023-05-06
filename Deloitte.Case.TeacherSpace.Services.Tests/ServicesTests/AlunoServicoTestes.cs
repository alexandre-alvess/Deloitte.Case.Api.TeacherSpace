using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Deloitte.Case.TeacherSpace.Services.Services;
using Moq;
using Xunit;

namespace Deloitte.Case.TeacherSpace.Services.Tests.ServicesTests
{
    public class AlunoServicoTestes
    {
        [Fact]
        public async Task AdicionarAluno_Sucesso()
        {
            var modelTeste = new AlunoModel
            {
                DataNascimento = DateTime.Now,
                Nome = "Maicon Silva",
                Email = "maicon.silva@example.com",
            };

            var resultado = await AdicionarAlunoCrudMock(modelTeste, ehValido: true);

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.StatusOk);
            Assert.NotNull(resultado.Dado);
            Assert.Equal(modelTeste.Nome.ToLower(), resultado.Dado.Nome.ToLower());
            Assert.Equal(modelTeste.Email, resultado.Dado.Email);
            Assert.IsType<DateTime>(resultado.Dado.DataNascimento);
        }

        [Fact]
        public async Task AdicionarAluno_Falha()
        {
            var resultado = await AdicionarAlunoCrudMock(new AlunoModel
            {
                DataNascimento = DateTime.Now,
                Email = "mateus@teste.com",
                Nome = "Mateus dos testes"
            }, ehValido: false);

            //Assert
            Assert.NotNull(resultado);
            Assert.False(resultado.StatusOk);
            Assert.Equal("Falha ao tentar criar registro no banco de dados", resultado.Erros.First());
        }

        [Fact]
        public async Task AtualizarAluno_Sucesso()
        {
            var modelTeste = new AlunoModel
            {
                DataNascimento = DateTime.Now,
                Nome = "Maicon Silva",
                Email = "maicon.silva@example.com",
            };

            var resultado = await AtualizarAlunoCrudMock(modelTeste, ehValido: true);

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.StatusOk);
            Assert.NotNull(resultado.Dado);
            Assert.Equal(modelTeste.Nome.ToLower(), resultado.Dado.Nome.ToLower());
            Assert.Equal(modelTeste.Email, resultado.Dado.Email);
            Assert.IsType<DateTime>(resultado.Dado.DataNascimento);
        }

        [Fact]
        public async Task AtualizarAluno_Falha()
        {
            var modelTeste = new AlunoModel
            {
                DataNascimento = DateTime.Now,
                Nome = "Maicon Silva",
                Email = "maicon.silva@example.com",
            };

            var resultado = await AtualizarAlunoCrudMock(modelTeste, ehValido: false);

            //Assert
            Assert.NotNull(resultado);
            Assert.False(resultado.StatusOk);
            Assert.Equal("Falha ao tentar criar registro no banco de dados", resultado.Erros.First());
        }

        private async Task<DataResult<AlunoModel>> AdicionarAlunoCrudMock(AlunoModel modelTeste, bool ehValido)
        {
            //Arrange

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AlunoModel, Aluno>(It.IsAny<AlunoModel>())).Returns(new Aluno
            {
                Nome = modelTeste.Nome,
                Email = modelTeste.Email,
                DataNascimento = modelTeste.DataNascimento,
                Ativo = true
            });

            mockMapper.Setup(m => m.Map<Aluno, Pessoa>(It.IsAny<Aluno>())).Returns(new Pessoa());

            var mockRepositorio = new Mock<IAlunoRepositorio>();
            SetRepositorioCriarMock(mockRepositorio, ehValido);

            var servico = new AlunoServico(mockRepositorio.Object, mockMapper.Object);

            //Act
            return await servico.Criar(modelTeste);
        }

        private void SetRepositorioCriarMock(Mock<IAlunoRepositorio> mockRepositorio, bool ehValido)
        {
            mockRepositorio.Setup(m => m.Criar(It.IsAny<Aluno>()))
                .Returns(Task.FromResult(ehValido
                    ? DataResult<Aluno>.Successo(new Aluno
                    {
                        Nome = "Maicon Silva",
                        Email = "maicon.silva@example.com",
                        DataNascimento = new DateTime(1958, 1 , 1),
                        Id = Guid.NewGuid(),
                        Ativo = true
                    }) : DataResult<Aluno>.Falha("Falha ao tentar criar registro no banco de dados")));
        }

        private async Task<DataResult<AlunoModel>> AtualizarAlunoCrudMock(AlunoModel modelTeste, bool ehValido)
        {
            //Arrange

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AlunoModel, Aluno>(It.IsAny<AlunoModel>())).Returns(new Aluno
            {
                Nome = modelTeste.Nome,
                Email = modelTeste.Email,
                DataNascimento = modelTeste.DataNascimento,
                Ativo = true, 
                Pessoa = new Pessoa
                { 
                    Id = Guid.NewGuid()
                }
            });

            mockMapper.Setup(m => m.Map<Aluno, Pessoa>(It.IsAny<Aluno>())).Returns(new Pessoa());

            var mockRepositorio = new Mock<IAlunoRepositorio>();
            SetRepositorioAtualizarMock(mockRepositorio, ehValido);

            var servico = new AlunoServico(mockRepositorio.Object, mockMapper.Object);

            //Act
            return await servico.Atualizar(modelTeste);
        }

        private void SetRepositorioAtualizarMock(Mock<IAlunoRepositorio> mockRepositorio, bool ehValido)
        {
            mockRepositorio.Setup(m => m.Consultar(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Aluno
                {
                    Nome = "Maicon Silva",
                    Email = "maicon.silva@example.com",
                    DataNascimento = new DateTime(1958, 1, 1),
                    Id = Guid.NewGuid(),
                    Ativo = true,
                    Pessoa = new Pessoa
                    {
                        Id = Guid.NewGuid()
                    }
                }));

            mockRepositorio.Setup(m => m.Atualizar(It.IsAny<Aluno>()))
                .Returns(Task.FromResult(ehValido
                    ? DataResult<Aluno>.Successo(new Aluno
                    {
                        Nome = "Maicon Silva",
                        Email = "maicon.silva@example.com",
                        DataNascimento = new DateTime(1958, 1, 1),
                        Id = Guid.NewGuid(),
                        Ativo = true
                    }) : DataResult<Aluno>.Falha("Falha ao tentar criar registro no banco de dados")));
        }
    }
}
