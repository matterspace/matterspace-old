﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class Idea: Thread
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public IdeaStatus? IdeaStatus { get; set; }
    }
}
