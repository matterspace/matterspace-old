using Matterspace.Model.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [Required()]
        public int CategoryId { get; set; }

        [DisplayName("Select a category")]
        public ThreadCategoryViewModel Category
        {
            get
            {
                return this.Product.Categories.FirstOrDefault(x => x.Id == this.CategoryId);
            }
        }
    }
}