using MicroServiceDechets.Application.Dto;
using MicroServiceDechets.Application.Service;
using MicroServiceDechets.Domain.Entity;
using MicroServiceDechets.Domain.Ports;
using MicroServiceDechets.Infrastructure.Data;
using MicroServiceDechets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Dechet>, DechetRepository>();
builder.Services.AddScoped<IService<DechetDtoReceive, DechetDtoSend>, DechetService>();

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