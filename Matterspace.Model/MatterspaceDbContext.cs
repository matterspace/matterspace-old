using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Identity
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("UserRole");

            // Entity configuration

            // Product
            modelBuilder.Entity<Product>().Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(40).HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_Name", 1) { IsUnique = true })
                    );

            modelBuilder.Entity<Product>().Property(m => m.DisplayName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>().Property(m => m.ShortDescription).HasMaxLength(120);

            modelBuilder.Entity<Product>().Property(m => m.WebsiteUrl)
                .IsRequired()
                .HasMaxLength(512);

            modelBuilder.Entity<Product>().Property(m => m.FacebookUrl)
                .HasMaxLength(512);

            modelBuilder.Entity<Product>().Property(m => m.TwitterUrl)
                .HasMaxLength(512);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Members)
                .WithRequired(x => x.Product);

            modelBuilder.Entity<Thread>()
                .HasRequired(t => t.Product)
                .WithMany(p => p.Threads)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thread>()
                .HasOptional(t => t.Category)
                .WithMany(p => p.Threads)
                .WillCascadeOnDelete(false);

            // ApplicationUserNotification
            modelBuilder.Entity<ApplicationUserNotification>()
                .HasRequired(m => m.TargetUser)
                .WithMany(m => m.Notifications);

            // ThreadReference
            modelBuilder.Entity<ThreadReference>()
                .HasRequired(tr => tr.ReferencedThread)
                .WithMany(t => t.ReferencesImReferenced);

            modelBuilder.Entity<ThreadReference>()
                .HasOptional(tr => tr.RefererThread)
                .WithMany(t => t.ReferencesImReferer);

            modelBuilder.Entity<ThreadReference>()
                .HasOptional(tr => tr.RefererThreadReply)
                .WithMany(tr => tr.ThreadReferencesImReferer);

            // ApplicationUserFollowingProduct
            modelBuilder.Entity<ApplicationUserFollowingThread>()
                .HasRequired(m => m.Thread)
                .WithMany(m => m.UsersFollowing);

            modelBuilder.Entity<ApplicationUserFollowingThread>()
                .HasRequired(m => m.User)
                .WithMany(m => m.ThreadsImFollowing);

            // ApplicationUserFollowingProduct
            modelBuilder.Entity<ApplicationUserFollowingProduct>()
                .HasRequired(m => m.User)
                .WithMany(m => m.ProductsImFollowing);

            modelBuilder.Entity<ApplicationUserFollowingProduct>()
                .HasRequired(m => m.Product)
                .WithMany(m => m.UsersFollowing);


        }

        public DbSet<ApplicationUserFollowingProduct> ApplicationUserFollowingProducts { get; set; }
        public DbSet<ApplicationUserFollowingThread> ApplicationUserFolloingThreads { get; set; }
        public DbSet<ApplicationUserNotification> ApplicationUserNotifications { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ThreadCategory> ThreadCategories { get; set; }
        public DbSet<ProductMember> ProductMembers { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<ThreadReference> ThreadReferences { get; set; }
        public DbSet<ThreadRelease> ThreadReleases { get; set; }
        public DbSet<ThreadReply> ThreadReplies { get; set; }
        public DbSet<ThreadReplyVote> ThreadReplyVotes { get; set; }
        public DbSet<ThreadVote> ThreadVotes { get; set; }
        public DbSet<ThreadStatusChangeEvent> ThreadStatusChangeEvents { get; set; }
    }
}