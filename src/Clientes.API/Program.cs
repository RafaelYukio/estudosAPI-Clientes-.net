using Clientes.Infra.IoC;
using System;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbInjections(builder.Configuration);
// Variáveis definidas no docker para container do SQL
// Tutorial de configuração do Docker:
// https://www.youtube.com/watch?v=hpLvXNASyTI&list=FLawtE1QiQ3kttrk_KBFfGxw&index=1&pp=gAQB
// https://www.twilio.com/blog/containerize-your-aspdotnet-core-application-and-sql-server-with-docker

// Para arrumar o erro de conexão na imagem do SQL (resposta de sayago69):
// https://github.com/dotnet/SqlClient/issues/633

string dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
string dbName = Environment.GetEnvironmentVariable("DB_NAME");
string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
builder.Services.AddDockerDbInjections(dbServer, dbName, dbPassword);

builder.Services.AddClienteInjections();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.ApplyPendingMigration();

app.Run();

// Para ter uma referência desta classe e utilizar nos testes de integração:
public partial class Program { }