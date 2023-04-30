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

// Configuração do escopo para obter a referência do banco de dados.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TeacherSpaceContext>(options => options.UseSqlServer(connectionString));

// Configuração e inicialização dos serviços e repositórios por injeção de dependência.
StartupService.Inicialize(builder.Services);

// Configuração dos mapeamentos "AutoMapper" por injeção de dependência.
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

// Adicionando o middleware para o tratamento global de exceções.
app.AddGlobalErrorHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
