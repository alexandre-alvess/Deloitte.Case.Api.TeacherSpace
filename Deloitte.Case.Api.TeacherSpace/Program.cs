using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Mapeamentos;
using Deloitte.Case.TeacherSpace.Core.Extensoes;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Services.Models;
using Deloitte.Case.TeacherSpace.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APITeacherSpace", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization Header - Utilizado com Bearer Authentication.\r\n\r\n" +
                      "Digite 'Bearer' [espa�o] e ent�o o token no campo abaixo.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

#region Configura��es Contexto/Servi�os/AutoMapper

// Configura��o do escopo para obter a refer�ncia do banco de dados.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TeacherSpaceContext>(options => options.UseSqlServer(connectionString));

// Configura��o e inicializa��o dos servi�os e reposit�rios por inje��o de depend�ncia.
StartupService.Inicialize(builder.Services);

// Configura��o dos mapeamentos "AutoMapper" por inje��o de depend�ncia.
var configuracaoMapeamentos = new MapperConfiguration(cfg =>
{
    cfg.AllowNullDestinationValues = true;
    AutoMapeamentos.Inicialize(cfg);
}).CreateMapper();

builder.Services.AddSingleton(configuracaoMapeamentos);

#endregion

#region Autentica��o/Autoriza��o JWT

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var secretKey = appSettingsSection.Get<AppSettings>().ChaveSecreta;

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = false;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false,

        // Valida a assinatura de um token recebido
        ValidateIssuerSigningKey = true,

        // Verifica se o token recebido ainda � v�lido
        ValidateLifetime = true,

        // Tempo de toler�ncia para a expira��o de um token (utilizado
        // caso haja problemas de sincronismo de hor�rio entre diferentes
        // computadores envolvidos no processo de comunica��o)
        ClockSkew = TimeSpan.Zero
    };

});

// Ativa o uso do Token como forma de autorizar o acesso aos recursos da aplica��o.
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adicionando o middleware para o tratamento global de exce��es.
app.AddGlobalErrorHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
