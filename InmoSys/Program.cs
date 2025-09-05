using InmoSys.Extensions;
using InmoSys.Middleware;
using Microsoft.EntityFrameworkCore;
using Owner.Infrastructure.EF.Extensions;
using Properties.Infrastructure.EF.Extensions;
using User.Infrastructure.EF.Context;

var builder = WebApplication.CreateBuilder(args);

// Configs (Leídos desde appsettings)
builder.Services.AddOptions();

builder.Services.AddDbContext<InmoSysCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionInmoSysCore")));

// CORS
builder.Services.AddInmoCors(builder.Configuration);

// JWT Auth
builder.Services.AddInmoJwtAuthentication(builder.Configuration);

// Controllers 
builder.Services.AddControllers();

// Swagger (se registra pero se controla si se expone en runtime)
builder.Services.AddInmoSwagger(builder.Configuration);

builder.Services.AddInfrastructure();
builder.Services.AddOwnerContexts();
builder.Services.AddPropertiesContexts();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InmoSysCoreContext>();
    if (db.Database.CanConnect())
    {
        Console.WriteLine("Conexión a InmoSysCore establecida correctamente.");
    }
    else
    {
        Console.WriteLine("No se pudo conectar a la base de datos InmoSysCore.");
    }
}

// Middleware pipeline
app.UseHttpsRedirection();

// Custom request logging middleware (ejemplo)
app.UseMiddleware<RequestLoggingMiddleware>();

// CORS
app.UseCors("InmoSysCors");

// AuthN & AuthZ
app.UseAuthentication();
app.UseAuthorization();

// Swagger
app.UseInmoSwagger(builder.Configuration, app.Environment);

// Map controllers
app.MapControllers();

await app.RunAsync();
