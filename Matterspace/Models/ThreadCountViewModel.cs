using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ThreadCountViewModel
    {
        public ThreadType Type { get; set; }

        public int Count { get; set; }
    }
}