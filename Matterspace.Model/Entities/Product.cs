﻿using System.Collections.Generic;

namespace Matterspace.Model.Entities
{
    public class Product
    {
        public Product()
        {
            this.Members = new List<ProductMember>();
            this.Releases = new List<Release>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name. This has to be a URL friendly name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// This is a small text that will be displayed in the product header
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// This is a long description that will be displayed in the "Home" tab
        /// </summary>
        public string LongDescriptionMarkdown { get; set; }

        public byte[] Avatar { get; set; }
        
        public ICollection<ProductMember> Members { get; set; }

        public ICollection<Release> Releases { get; set; }
    }
}