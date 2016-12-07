﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public class ProductViewModel
    {
        /// <summary>
        /// This is not an actual URL, but the URL part like matterspace.io/[this].
        /// This is the Name in the Product entity
        /// </summary>
        [DisplayName("Matterspace product URL")]
        [Required]
        [RegularExpression("^([a-z0-9](?:-?[a-z0-9]){0,39})$", ErrorMessage = "The Matterspace product URL can only contain alphanumeric characters and hyphens; They cannot start with, end with, or have consecutive hyphens. The maximum size is 40 characters.")]
        [StringLength(40)]
        public string Name { get; set; }

        [DisplayName("Product display name")]
        [Required(ErrorMessage = "The product display name is required.")]
        [StringLength(40)]
        public string DisplayName { get; set; }

        [DisplayName("Short description")]
        [StringLength(120, ErrorMessage = "The short description can be no longer than 120 characters.")]
        public string ShortDescription { get; set; }

        [DisplayName("Website URL")]
        [StringLength(512, ErrorMessage = "The website URL can be no longer than 512 characters.")]
        [Url(ErrorMessage = "The website URL must be valid")]
        [Required(ErrorMessage = "The website URL is required. Make sure it starts with http:// or https://")] // todo: Fix this. http shouldn't be required
        public string WebsiteUrl { get; set; }
    }
}