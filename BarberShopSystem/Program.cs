using BarberShopSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Se añaden los servicios al contenedor.
builder.Services.AddScoped<ReservasService>();
builder.Services.AddScoped<ProfesionalesService>();

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
