using Microsoft.EntityFrameworkCore;
using BackendApiLogistica.Data;
using Microsoft.OpenApi.Models;
using BackendApiLogistica.Repositories.Interfaces; 
using BackendApiLogistica.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackendApiLogistica.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Servicios al contenedor
builder.Services.AddControllers();

// Configura Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendApiLogistica", Version = "v1" });
});

// Conexión a base de datos
builder.Services.AddDbContext<GestionLogisticaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IBodegaRepository, BodegaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IPuertoRepository, PuertoRepository>();
builder.Services.AddScoped<IEnvioMaritimoRepository, EnvioMaritimoRepository>();
builder.Services.AddScoped<IEnvioTerrestreRepository, EnvioTerrestreRepository>();

// Configuración CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Origen para la app Angular
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplica CORS
app.UseCors("AllowAngularApp");

// Middleware de errores
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
