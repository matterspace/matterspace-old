using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public enum ThreadType
    {
        Idea = 1,
        Issue = 2,
        BacklogItem = 3,
        Question = 4,
        QA = 5,
        Doc = 6,
        Release = 7
    }

    public class ThreadViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public ThreadType ThreadType { get; set; }

        public string Content { get; set; }

        public ProductViewModel Product { get; set; }
    }
}