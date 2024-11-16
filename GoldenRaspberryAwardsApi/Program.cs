using GoldenRaspberryAwards.Domain.Services.Interfaces;
using GoldenRaspberryAwards.Domain.Services;
using GoldenRaspberryAwards.Infra.Repository.Interfaces;
using GoldenRaspberryAwards.Infra.Repository;
using GoldenRaspberryAwards.Infra.Services.Interfaces;
using GoldenRaspberryAwards.Infra.Services;
using GoldenRaspberryAwards.Infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGoldenRaspberryAwardServices, GoldenRaspberryAwardServices>();

builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<ICsvInfraService, CsvInfraService>();

builder.Services.AddScoped<IGoldenRaspberryAwardRepository, GoldenRaspberryAwardRepository>()
    .AddDbContext<GoldenRaspberryAwardsContext>(_ => _.UseInMemoryDatabase("GoldenRaspberryAwards"));

ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
var csvService = serviceProvider.GetService<ICsvService>();

await csvService.LoadMovieListCsv();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// Compartilha os recursos da class Program para tests de integração
/// </summary>
public partial class Program { } 
