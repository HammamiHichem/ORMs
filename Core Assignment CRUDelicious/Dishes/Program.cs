using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dishes.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le contexte de base de données
builder.Services.AddDbContext<MyContext>(options =>
{
    // Récupérer la chaîne de connexion à partir de appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    // Configurer Entity Framework Core pour utiliser MySQL
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Ajouter les services MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurer le pipeline de requête HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
