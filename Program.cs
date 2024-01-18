using Microsoft.EntityFrameworkCore;
using Projeto_CriaBoletosParaBancos.Dados;

var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("BoletoParaBancosConnection");

// Add services to the container.

builder.Services.AddDbContext<ContextoBancoDeDados>(opts =>
opts.UseMySql(conString, ServerVersion.AutoDetect(conString)));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Run();
