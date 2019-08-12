using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewFurnitureStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }
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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FurnitureStore.Models.WoodType> WoodTypes { get; set; }

        public System.Data.Entity.DbSet<FurnitureStore.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<FurnitureStore.Models.ProductType> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<FurnitureStore.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<NewFurnitureStore.Models.Order> Orders { get; set; }

    }
}