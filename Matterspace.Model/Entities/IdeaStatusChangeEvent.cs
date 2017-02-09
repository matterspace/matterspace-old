﻿using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class IdeaStatusChangeEvent: ThreadStatusChangeEvent
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IdeaStatus? IdeaStatusFrom { get; set; }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IdeaStatus? IdeaStatusTo { get; set; }
    }
}
