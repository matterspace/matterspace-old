using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class CreateProductViewModel
    {
        [DisplayName("Product URL")]
        [Required]
        [RegularExpression("^([a-z0-9](?:-?[a-z0-9]){0,39})$", ErrorMessage = "The Product URL can only contain alphanumeric characters and hyphens; They cannot start with, end with, or have consecutive hyphens. The maximum size is 40 characters.")]
        [StringLength(40)]
        public string ProductUrlName { get; set; }

        [DisplayName("Product display name")]
        [Required(ErrorMessage = "The product display name is required.")]
        [StringLength(40)]
        public string ProductDisplayName { get; set; }

        [DisplayName("Short description")]
        [StringLength(120, ErrorMessage = "The short description can be no longer than 120 characters.")]
        public string ShortDescription { get; set; }
    }
}