using System;
using System.Collections.Generic;

namespace Matterspace.Model.Entities
{
    public class ThreadReply
    {
        public ThreadReply()
        {
            this.ThreadReferencesImReferer = new List<ThreadReference>();
        }

        public int Id { get; set; }

        /// <summary>
        /// User that created this thread
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// User that created this thread
        /// </summary>
        public ApplicationUser Author { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Text in markdown form
        /// </summary>
        public string TextMarkdown { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public ICollection<ThreadReference> ThreadReferencesImReferer { get; set; }
    }
}
