using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class Thread
    {
        public Thread()
        {
            this.Replies = new List<ThreadReply>();
            this.Descendents = new List<Thread>();
            this.Releases = new List<ThreadRelease>();
            this.ReferencesImReferenced = new List<ThreadReference>();
            this.ReferencesImReferer = new List<ThreadReference>();
            this.StatusChangeEvents = new List<ThreadStatusChangeEvent>();
        }

        public int Id { get; set; }

        public ThreadType ThreadType { get; set; }

        /// <summary>
        /// User that created this thread
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// User that created this thread
        /// </summary>
        public ApplicationUser Author { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? ParentThreadId { get; set; }

        /// <summary>
        /// When a thread is "converted" to a different type of thread (Example: And idea being converted into a backlog
        /// item), we change the ThreadType of the thread, so all data will be kept, but we create a "shadow", readonly version
        /// of it. The reason is that, when I look at the accepted ideas, I want to see the idea there, even though it's now
        /// a BacklogItem, not an Idea anymore.
        /// </summary>
        public Thread ParentThread { get; set; }

        /// <summary>
        /// Text in markdown form
        /// </summary>
        public string TextMarkdown { get; set; }


        public ICollection<ThreadReply> Replies { get; set; }

        /// <summary>
        /// If I'm a "shadow" thread, then I'll have a descendent.
        /// TODO: This shouldn't be a list. There should be 0 or 1 descendent per thread
        /// </summary>
        public ICollection<Thread> Descendents;

        public ICollection<ThreadRelease> Releases { get; set; }

        public ICollection<ThreadReference> ReferencesImReferenced { get; set; }

        public ICollection<ThreadReference> ReferencesImReferer { get; set; }

        public ICollection<ThreadStatusChangeEvent> StatusChangeEvents { get; set; }
    }
}
