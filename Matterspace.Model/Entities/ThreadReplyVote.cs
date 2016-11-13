using System;

namespace Matterspace.Model.Entities
{
    public class ThreadReplyVote
    {
        public int Id { get; set; }

        /// <summary>
        /// User that voted
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User that voted
        /// </summary>
        public ApplicationUser User { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Thread this vote is for
        /// </summary>
        public int ThreadId { get; set; }

        /// <summary>
        /// Thread this vote is for
        /// </summary>
        public Thread Thread { get; set; }
    }
}
