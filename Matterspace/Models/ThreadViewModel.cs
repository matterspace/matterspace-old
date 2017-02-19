using Matterspace.Model.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Matterspace.Models
{
    public class ThreadViewModel
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public string Title { get; set; }

        public ThreadType Type { get; set; }

        public ThreadStatus Status { get; set; }

        public string Content { get; set; }

        public ProductViewModel Product { get; set; }

        public DateTime CreatedAt { get; set; }

        public string RelativeDate { get; set; }

        [Required()]
        public int? CategoryId { get; set; }

        private ThreadCategoryViewModel _category { get; set; }

        [DisplayName("Select a category")]
        public ThreadCategoryViewModel Category
        {
            get
            {
                // If a thread does not have a category (eg: it was deleted)
                // Return an uncategorized one
                return _category != null
                    ? _category
                    : new ThreadCategoryViewModel
                    {
                        Name = "Uncategorized"
                    };
            }
            set
            {
                this._category = value;
            }
        }
    }
}