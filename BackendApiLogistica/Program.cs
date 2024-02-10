using Microsoft.EntityFrameworkCore;
using BackendApiLogistica.Data; // Ajusta este espacio de nombres seg�n corresponda
using Microsoft.OpenApi.Models;
using BackendApiLogistica.Repositories.Interfaces; // Aseg�rate de que este es el espacio de nombres correcto para tus interfaces
using BackendApiLogistica.Repositories; // Aseg�rate de que este es el espacio de nombres correcto para tus implementaciones de repositorio

// Importa tus interfaces y clases de repositorio aqu�
// Por ejemplo, si tienes otras interfaces o clases de repositorio, aseg�rate de importarlas aqu�.

var builder = WebApplication.CreateBuilder(args);

// A�ade los servicios al contenedor.
builder.Services.AddControllers();
// Configuraci�n de Swagger/OpenAPI
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
// Contin�a registrando los dem�s repositorios de la misma manera, por ejemplo:
// builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
// builder.Services.AddScoped<IPuertoRepository, PuertoRepository>();
// builder.Services.AddScoped<IEnvioMaritimoRepository, EnvioMaritimoRepository>();
// builder.Services.AddScoped<IEnvioTerrestreRepository, EnvioTerrestreRepository>();

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
