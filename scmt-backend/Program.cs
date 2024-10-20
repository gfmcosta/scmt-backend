using System.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using scmt_backend.Data;
using scmt_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Registar o serviço de envio de e-mail
builder.Services.AddTransient<IEmailService, EmailService>();

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure o ASP.NET Core Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    {
        options.SignIn.RequireConfirmedAccount = true; // Exige confirmação de conta
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Adicione MVC
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure o pipeline de requisições
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Middleware de identificação
app.UseMiddleware<CheckUserExistsMiddleware>();

// Mapeamento de rotas
app.MapRazorPages(); // Adicione isto para mapear as páginas do Identity
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();