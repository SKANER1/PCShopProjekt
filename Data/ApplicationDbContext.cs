using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCShopProjekt.Models;

namespace PCShopProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PCShopProjekt.Models.Zlecenia> Zlecenia { get; set; } = default!;
        public DbSet<PCShopProjekt.Models.Klienci> Klienci { get; set; } = default!;
        public DbSet<PCShopProjekt.Models.Technicy> Technicy { get; set; } = default!;
        public DbSet<PCShopProjekt.Models.Urzadzenia> Urzadzenia { get; set; } = default!;
        public DbSet<PCShopProjekt.Models.Platnosci> Platnosci { get; set; } = default!;
        public DbSet<PCShopProjekt.Models.Uslugi> Uslugi { get; set; } = default!;
    }
}
