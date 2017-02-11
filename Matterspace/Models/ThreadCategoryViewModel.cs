using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ThreadCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public ThreadType ThreadType { get; set; }

        public IEnumerable<ThreadViewModel> Threads { get; set; }
    }
}