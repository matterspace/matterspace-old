using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class BacklogItemStatusChangeEvent: ThreadStatusChangeEvent
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public BacklogItemStatus? BacklogItemStatusFrom { get; set; }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public BacklogItemStatus? BacklogItemStatusTo { get; set; }
    }
}
