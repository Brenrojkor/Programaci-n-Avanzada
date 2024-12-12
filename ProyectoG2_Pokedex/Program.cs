using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using ProyectoG2_Pokedex.Data;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("Minombredeconexion");

builder.Services.AddDbContext<MinombredeconexionDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString) // Detecta la versi�n del servidor MySQL autom�ticamente
    ));

// Configuraci�n de logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});

// Habilitar sesiones
builder.Services.AddDistributedMemoryCache(); // Usar memoria para almacenar sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiraci�n de la sesi�n
    options.Cookie.HttpOnly = true; // Aumenta la seguridad
    options.Cookie.IsEssential = true; // Necesario para GDPR
});

// Agregar soporte para controladores y vistas
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new SimpleTypeModelBinderProvider());
});

var app = builder.Build();

// Configuraci�n para entornos no de desarrollo
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Habilitar el uso de sesiones
app.UseAuthorization();

// Middleware de depuraci�n (opcional)
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");
    Console.WriteLine($"Request Method: {context.Request.Method}");
    await next.Invoke();
});

// Configuraci�n de rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Iniciar la aplicaci�n
app.Run();

