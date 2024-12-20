using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using ProyectoG2_Pokedex.Data;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("Minombredeconexion");

builder.Services.AddDbContext<MinombredeconexionDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new SimpleTypeModelBinderProvider());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");
    Console.WriteLine($"Request Method: {context.Request.Method}");
    await next.Invoke();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

