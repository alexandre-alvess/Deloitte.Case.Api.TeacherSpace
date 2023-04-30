using AutoMapper;
using Deloitte.Case.Api.TeacherSpace.Mapeamentos;
using Deloitte.Case.TeacherSpace.Core.Extensoes;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
