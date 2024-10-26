using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using scmt_backend.Models;

namespace scmt_backend.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Aqui você pode adicionar DbSets para outras entidades que deseja mapear para o banco de dados
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Submenu> Submenus { get; set; }
    public DbSet<FAQ> Faqs { get; set; }
}