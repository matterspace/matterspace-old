using System;

namespace Matterspace.Model.Entities
{
    public class ApplicationUserFollowingThread
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public DateTime StartedAt { get; set; }
    }
}
