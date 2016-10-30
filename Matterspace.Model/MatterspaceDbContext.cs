using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Matterspace.Model
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class MatterspaceDbContext : IdentityDbContext<ApplicationUser>
    {
        public MatterspaceDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MatterspaceDbContext Create()
        {
            return new MatterspaceDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("UserRole");
        }
    }
}