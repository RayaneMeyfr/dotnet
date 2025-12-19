using MicroServiceTransport.Application.Dto;
using MicroServiceTransport.Application.Service;
using MicroServiceTransport.Domain.Entity;
using MicroServiceTransport.Domain.Ports;
using MicroServiceTransport.Infrastructure.Data;
using MicroServiceTransport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Transport>, TransportRepository>();
builder.Services.AddScoped<IService<TransportDtoReceive, TransportDtoSend, TransportDtoSendEmission>, TransportService>();

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