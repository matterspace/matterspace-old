using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ThreadCategoryViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Category name")]
        [Required(ErrorMessage = "The category name is required.")]
        [StringLength(80, ErrorMessage = "The category is used only for giving an idea of what your thread is. It can't take more than 80 characters")]
        public string Name { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        [DisplayName("Thread type")]
        [Required(ErrorMessage = "The category type is required.")]
        public ThreadType ThreadType { get; set; }

        public IEnumerable<ThreadViewModel> Threads { get; set; }
    }
}