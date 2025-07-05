using Microsoft.EntityFrameworkCore;
using Pizzaria.Pedidos.API.HttpClients;
using Pizzaria.Pedidos.API.Persistencia;
using Pizzaria.Pedidos.API.Services;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceDiscovery(options =>
options.UseConsul());
// Add services to the container.
builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PedidoDbContext>(options => options.UseInMemoryDatabase("pedidos"));

builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddHttpClient<PizzaApiHttpClient.Client>(options
    => options.BaseAddress = new Uri("http://pizzariapizzaapi:8080")).AddServiceDiscovery();

builder.Services.AddHttpClient<NoticacoesApiHttpClient.Clients>(options
    => options.BaseAddress = new Uri("http://pizzarianotificacoesapi:8080")).AddServiceDiscovery();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHealthChecks("/health");

  app.UseSwagger();
  app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
