using MicroServiceEnergie.Application.Dto;
using MicroServiceEnergie.Application.Service;
using MicroServiceEnergie.Domain.Entity;
using MicroServiceEnergie.Domain.Ports;
using MicroServiceEnergie.Infrastructure.Data;
using MicroServiceEnergie.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Energie>, EnergieRepository>();
builder.Services.AddScoped<IService<EnergieDtoReceive, EnergieDtoSend>, EnergieService>();

string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();