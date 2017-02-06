using Matterspace.Model;
using Matterspace.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Matterspace.Lib.Services.Settings
{
    public class SettingsService
    {
        public SettingsService(MatterspaceDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            this.Db = db;
        }

        public MatterspaceDbContext Db { get; }

        public async Task AddMemberToProject(string username, int productId, string userId = null)
        {
            // Get the user by its username
            // If the id is not null (found user with auto complete), use its id
            var memberId = !string.IsNullOrEmpty(userId) ? userId
                : await this.Db.Users
                .Where(x => x.UserName == username)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            // Creates a new product member
            var productMember = new ProductMember()
            {
                MembershipType = Model.Enums.ProductMembershipType.Member,
                ProductId = productId,
                MemberId = memberId
            };

            // Save the new member
            this.Db.ProductMembers.Add(productMember);
            await this.Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersByUsername(string username)
        {
            var members = await this.Db.Users
                .Where(x => x.UserName.Contains(username))
                .Select(x => new ApplicationUser() {
                    Id = x.Id,
                    UserName = x.UserName
                })
                .ToListAsync();

            return members;
        }
    }
}