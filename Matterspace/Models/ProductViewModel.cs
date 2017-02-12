using Matterspace.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Matterspace.Models
{
    /// <summary>
    /// Indicates the selected tab
    /// </summary>
    public enum ProductActiveTab
    {
        Home,
        Ideas,
        Issues,
        Backlog,
        QA,
        Docs,
        Releases,
        Settings
    }

    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.Threads = new List<ThreadViewModel>();
            this.ThreadsCount = new List<ThreadCountViewModel>();
            this.Members = new List<ApplicationUserViewModel>();
            this.Categories = new List<ThreadCategoryViewModel>();
        }

        public int? Id { get; set; }
        
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ShortDescription { get; set; }

        public string WebsiteUrl { get; set; }

        public ProductActiveTab ActiveTab { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public IEnumerable<ThreadCountViewModel> ThreadsCount { get; set; }

        public IEnumerable<ThreadViewModel> Threads { get; set; }

        public IEnumerable<ApplicationUserViewModel> Members { get; set; }

        public IEnumerable<ThreadCategoryViewModel> Categories { get; set; }

        /// <summary>
        /// Returns the thread count for the current product
        /// </summary>
        public int GetThreadCount(ThreadType threadType)
        {
            var currThread = this.ThreadsCount.FirstOrDefault(x => x.Type == threadType);
            return currThread != null ? currThread.Count : 0;
        }
    }
}