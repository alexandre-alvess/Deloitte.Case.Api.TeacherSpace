using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="UsuarioServico"/>.
    /// </summary>
    public class UsuarioServico : BaseServico<UsuarioModel, Usuario, IUsuarioRepositorio, UsuarioValidador>, IUsuarioServico
    {
        /// <summary>
        /// Define as configurações da aplicação.
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="UsuarioServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de usuário <see cref="IUsuarioRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        /// <param name="mapper">As configurações da aplicação <see cref="IMapper"/>.</param>
        public UsuarioServico(IUsuarioRepositorio repositorio, IMapper mapper, IOptions<AppSettings> appSettings) : base(repositorio, mapper)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Valida as crendeciais de autenticação do usuário.
        /// </summary>
        /// <param name="autenticacaoModel">Os dados de autenticação do usuário.</param>
        /// <returns>A validade das credenciais do usuário <see cref="DataResult{bool}"/>.</returns>
        public async Task<DataResult<bool>> ValideCredenciais(AutenticacaoModel autenticacaoModel)
        {
            var usuario = await _repositorio.Consultar(x =>
                x.Login.ToUpper() == autenticacaoModel.Login.ToUpper() &&
                x.Ativo);

            return usuario != null && usuario.Senha == autenticacaoModel.Senha
                ? DataResult<bool>.Successo(true)
                : DataResult<bool>.Falha("Login ou senha inválida.");
        }

        /// <summary>
        /// Autentica o usuário gerando o token com os dados do usuário.
        /// </summary>
        /// <param name="autenticacaoModel">Os dados de autenticação do usuário.</param>
        /// <returns>Os dados de autenticação do usuário <see cref="DataResult{UsuarioAutenticacao}"/>.</returns>
        public async Task<DataResult<UsuarioAutenticacao>> Autenticar(AutenticacaoModel autenticacaoModel)
        {
            var credencialResultado = await ValideCredenciais(autenticacaoModel);
            if (!credencialResultado.StatusOk)
                return DataResult<UsuarioAutenticacao>.Falha(credencialResultado.Erros);

            //var usuario = await _repositorio.Consultar(x => x.Login.ToUpper() == autenticacaoModel.Login.ToUpper(), i => i.Pessoa);
            var usuario = await ConsultarUsuarioParaAutenticacao(autenticacaoModel);

            var chaveSecreta = Encoding.ASCII.GetBytes(_appSettings.ChaveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Pessoa.Nome),
                    new Claim(ClaimTypes.Email, usuario.Login),
                    new Claim(ClaimTypes.Country, "Brasil"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Contexto", JsonConvert.SerializeObject(new
                    {
                        /* Claims ficticias */
                        TipoPerfil = EnumTipoPerfilUsuario.Professor,
                        Permissoes = new List<string>
                        {
                            "Registrar notas",
                            "Registrar alunos",
                            "Registrar professores",
                            "Registrar disciplinas",
                            "Registrar turmas"
                        }
                    }))
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.Date.AddDays(1).AddTicks(-1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveSecreta), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return DataResult<UsuarioAutenticacao>.Successo(new UsuarioAutenticacao
            {
                Token = tokenHandler.WriteToken(token),
                UsuarioId = usuario.Id,
                EntidadeId = usuario.EntidadId.GetValueOrDefault(),
                TipoPerfilUsuario = usuario.TipoPerfil
            });
        }

        protected override Task<DataResult<UsuarioModel>> AntesDeAdicionar(UsuarioModel model, Usuario entidade)
        {
            entidade.Pessoa = _mapper.Map<Usuario, Pessoa>(entidade);
            entidade.Pessoa.Id = Guid.NewGuid();
            entidade.TipoPerfil = EnumTipoPerfilUsuario.Professor;
            entidade.Pessoa.Nome = model.Nome;
            
            return Task.FromResult(DataResult<UsuarioModel>.Successo(model));
        }

        private async Task<Usuario> ConsultarUsuarioParaAutenticacao(AutenticacaoModel autenticacaoModel)
        {
            var dbContext = _repositorio.DbContext;

            var usuarioAuth = await (from usuario in dbContext.Usuarios
                                     join professor in dbContext.Professores on usuario.PessoaId equals professor.PessoaId into p
                                     from pp in p.DefaultIfEmpty()
                                     join aluno in dbContext.Alunos on usuario.PessoaId equals aluno.PessoaId into a
                                     from ap in a.DefaultIfEmpty()
                                     where usuario.Login.ToUpper() == autenticacaoModel.Login.ToUpper() && usuario.Senha == autenticacaoModel.Senha
                                     select new Usuario
                                     {
                                         Ativo = usuario.Ativo,
                                         Id = usuario.Id,
                                         Login = usuario.Login,
                                         Pessoa = usuario.Pessoa,
                                         PessoaId = usuario.PessoaId,
                                         Senha = usuario.Senha,
                                         TipoPerfil = usuario.TipoPerfil,
                                         EntidadId = pp != null ? pp.Id : ap != null ? ap.Id : null,
                                         
                                     }).FirstOrDefaultAsync();

            return usuarioAuth;
            //return null;
        }
    }
}
