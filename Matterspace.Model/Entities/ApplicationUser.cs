using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Matterspace.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Products = new List<ProductMember>();
            this.Threads = new List<Thread>();
            this.ThreadReplies = new List<ThreadReply>();
            this.ThreadVotes = new List<ThreadVote>();
            this.ThreadReplyVotes = new List<ThreadReplyVote>();
            this.ThreadStatusChangeEventsImAuthor = new List<ThreadStatusChangeEvent>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// Threads created by this user
        /// </summary>
        public ICollection<ProductMember> Products { get; set; }

        /// <summary>
        /// Threads created by this user
        /// </summary>
        public ICollection<Thread> Threads { get; set; }

        /// <summary>
        /// Threads created by this user
        /// </summary>
        public ICollection<ThreadReply> ThreadReplies { get; set; }

        /// <summary>
        /// ThreadVotes this user has casted
        /// </summary>
        public ICollection<ThreadVote> ThreadVotes { get; set; }

        /// <summary>
        /// ThreadReplyVotes this user has casted
        /// </summary>
        public ICollection<ThreadReplyVote> ThreadReplyVotes { get; set; }

        /// <summary>
        /// ThreadStatusChangeEvent this user is author
        /// </summary>
        public ICollection<ThreadStatusChangeEvent> ThreadStatusChangeEventsImAuthor { get; set; }
    }
}