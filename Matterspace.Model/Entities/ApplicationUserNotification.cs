using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    /// <summary>
    /// User notification.
    /// </summary>
    /// <remarks>
    ///  
    /// Notification types and configuration:
    /// 
    ///     UserThreadHasBeenReplied = 1
    ///         In this case, Thread and ThreadReply will be populated
    /// 
    ///     UserThreadHadItsStatusChanged = 2,
    ///         In this case, RelatedThreadStatusChangeEvent will be populated
    /// 
    ///     UserHasBeenMentioned = 3
    ///         In this case, either Thread or ThreadReply will be populated
    /// 
    /// </remarks>
    public class ApplicationUserNotification
    {
        public int Id { get; set; }

        public ApplicationUserNotificationType Type { get; set; }

        public string TargetUserId { get; set; }

        public ApplicationUser TargetUser { get; set; }

        public int? ThreadId { get; set; }

        public Thread Thread { get; set; }

        public int? ThreadReplyId { get; set; }
        
        /// <summary>
        /// IF this notification is about a thread reply
        /// </summary>
        public ThreadReply ThreadReply { get; set; }

        public int? RelatedThreadStatusChangeEventId { get; set; }

        public ThreadStatusChangeEvent RelatedThreadStatusChangeEvent { get; set; }

        public bool Read { get; set; }
    }
}
