﻿using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class IssueStatusChangeEvent: ThreadStatusChangeEvent
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IssueStatus? IssueStatusFrom { get; set; }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IssueStatus? IssueStatusTo { get; set; }
    }
}
