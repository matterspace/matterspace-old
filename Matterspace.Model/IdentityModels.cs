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
    }
}