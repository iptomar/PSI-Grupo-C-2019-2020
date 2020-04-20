using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BackOfficeRAM.Models.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BackOfficeRAM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RAMdb", throwIfV1Schema: false)
        {
        }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<PontoInteresse> PontosInteresse { get; set; }
        public DbSet<PontoRoteiro> PontoRoteiro { get; set; }
        public System.Data.Entity.DbSet<BackOfficeRAM.Models.Roteiro> Roteiroes { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}