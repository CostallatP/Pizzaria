using Microsoft.EntityFrameworkCore;
using Pizza.API.Persistencia;
using Pizza.API.Models;
using Pizza.API.Persistencia;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

/// PIZZA API
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<PizzaDbContext>(options => options.UseInMemoryDatabase("pizza"));
builder.Services.AddServiceDiscovery(options =>
options.UseConsul());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaRepository>();
builder.Services.AddScoped<EstoqueRepository>();


builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHealthChecks("/health");
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler("/error");

app.Run();
