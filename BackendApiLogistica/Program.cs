using Microsoft.EntityFrameworkCore;
using BackendApiLogistica.Data; // Asegúrate de que este es el espacio de nombres correcto para tu contexto de EF
using Microsoft.OpenApi.Models;
using BackendApiLogistica.Repositories.Interfaces; // Verifica el espacio de nombres de tus interfaces
using BackendApiLogistica.Repositories; // Verifica el espacio de nombres de tus implementaciones de repositorio
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackendApiLogistica.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Añade los servicios al contenedor.
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendApiLogistica", Version = "v1" });
});

// Registra GestionLogisticaContext con el contenedor de servicios DI
builder.Services.AddDbContext<GestionLogisticaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IBodegaRepository, BodegaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IPuertoRepository, PuertoRepository>();
builder.Services.AddScoped<IEnvioMaritimoRepository, EnvioMaritimoRepository>();
builder.Services.AddScoped<IEnvioTerrestreRepository, EnvioTerrestreRepository>();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Asegúrate de que este es el origen correcto para tu aplicación Angular
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplica la política CORS aquí antes de UseRouting y UseAuthorization
app.UseCors("AllowAngularApp");

// Registro del Middleware de Manejo de Errores
app.UseMiddleware<ErrorHandlingMiddleware>(); // Asegúrate de agregar esta línea

app.UseAuthorization();

app.MapControllers();

app.Run();
