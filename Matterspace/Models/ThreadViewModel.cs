using Matterspace.Model.Enums;

namespace Matterspace.Models
{
    public class ThreadViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public ThreadType Type { get; set; }

        public ThreadStatus Status { get; set; }

        public string Content { get; set; }

        public ProductViewModel Product { get; set; }
    }
}