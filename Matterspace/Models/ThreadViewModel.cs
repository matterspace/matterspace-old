using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ThreadViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public ThreadType Type { get; set; }

        public string Content { get; set; }

        public ProductViewModel Product { get; set; }
    }
}