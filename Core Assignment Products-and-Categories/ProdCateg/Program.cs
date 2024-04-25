using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Ajoutez vos services au conteneur.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurez le pipeline de requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Définissez vos routes de niveau supérieur ici
app.MapControllerRoute(
    name: "categories",
    pattern: "Home/Categories",
    defaults: new { controller = "Home", action = "Category" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
