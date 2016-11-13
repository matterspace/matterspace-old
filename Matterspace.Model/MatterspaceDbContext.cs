using System.Data.Entity;
using Matterspace.Model.Entities;
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

            // Identity
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("UserRole");
        }

        public DbSet<Thread> Threads { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMember> ProductMembers { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<ThreadReference> ThreadReferences { get; set; }
        public DbSet<ThreadRelease> ThreadReleases { get; set; }
        public DbSet<ThreadReply> ThreadReplies { get; set; }
        public DbSet<ThreadReplyVote> ThreadReplyVotes { get; set; }
        public DbSet<ThreadVote> ThreadVotes { get; set; }
    }
}