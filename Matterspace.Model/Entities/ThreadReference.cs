namespace Matterspace.Model.Entities
{
    /// <summary>
    /// Thread reference
    /// </summary>
    /// <remarks>
    /// The AUTHOR and the DATE of the reference SHOULD be inferred.
    /// IF the REFERER is a Thread, the AUTHOR and DATE are of that Thread.
    /// IF the REFERER is a ThreadReply, the AUTHOR and DATE are of that ThreadReply.
    /// </remarks>
    public class ThreadReference
    {
        public int Id { get; set; }

        /// <summary>
        /// Thread that has been refered
        /// </summary>
        public int ReferencedThreadId { get; set; }

        /// <summary>
        /// Thread that has been refered
        /// </summary>
        public Thread ReferencedThread { get; set; }

        /// <summary>
        /// Thread that refered another thread
        /// </summary>
        public int? RefererThreadId { get; set; }

        /// <summary>
        /// Thread that refered another thread
        /// </summary>
        public Thread RefererThread { get; set; }

        /// <summary>
        /// ThreadReply that refered another thread
        /// </summary>
        public int? RefererThreadReplyId { get; set; }

        /// <summary>
        /// ThreadReply that refered another thread
        /// </summary>
        public ThreadReply RefererThreadReply { get; set; }
    }
}
