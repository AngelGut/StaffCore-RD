using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Data;

var builder = WebApplication.CreateBuilder(args);

// ========== SERVICES ==========

// 1. DbContext
builder.Services.AddDbContext<StaffDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffCore")));

// 2. Identity con opciones de contraseña
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
})
.AddEntityFrameworkStores<StaffDbContext>()
.AddDefaultTokenProviders();

// 3. Controladores con Vistas
builder.Services.AddControllersWithViews();

// 4. Configurar cookie de autenticación
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// ========== MIDDLEWARE ==========

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ⚠️ ORDEN CRÍTICO: Authentication ANTES de Authorization
app.UseAuthentication();      // ← PRIMERO
app.UseAuthorization();       // ← DESPUÉS

// ========== CREAR ROLES AUTOMÁTICAMENTE ==========
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string[] rolesNeeded = { "Administrador", "RRHH", "Viewer" };

    foreach (var role in rolesNeeded)
    {
        var roleExists = await roleManager.RoleExistsAsync(role);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();