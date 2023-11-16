using BarberShopSystem.Models;
using BarberShopSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Se añaden los servicios al contenedor.
builder.Services.AddScoped<ReservasService>();
builder.Services.AddScoped<ProfesionalesService>();
builder.Services.AddScoped<ServiciosService>();

// Se hace inyección de dependencia de la BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "reservas",
    pattern: "reservas",
    defaults: new { controller = "Reservas", action = "Index" }
);

app.MapControllerRoute(
    name: "profesionales",
    pattern: "profesionales",
    defaults: new { controller = "Profesionales", action = "Index" }
);

app.Run();
