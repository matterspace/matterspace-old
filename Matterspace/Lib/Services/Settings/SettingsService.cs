using Matterspace.Model;
using Matterspace.Model.Entities;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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