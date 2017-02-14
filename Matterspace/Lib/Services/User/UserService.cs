using Matterspace.Models;
using System;
using System.Threading.Tasks;

namespace Matterspace.Lib.Services.User
{
    public class UserService
    {
        private readonly ApplicationUserManager _userManager;

        public UserService(ApplicationUserManager userManager)
        {
            if(userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            _userManager = userManager;
        }

        public async Task<UserViewModel> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return new UserViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id
            };
        }
    }
}