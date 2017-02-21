using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ThreadEntryViewModel
    {
        public ApplicationUserViewModel Author { get; set; }
        public string Content { get; set; }
    }
}