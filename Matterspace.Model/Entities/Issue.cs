using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class Issue: Thread
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IssueStatus? IssueStatus { get; set; }
    }
}
