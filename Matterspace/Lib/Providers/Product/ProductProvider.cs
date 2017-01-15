using Matterspace.Model;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Matterspace.Lib.Providers.Product
{
    public class ProductProvider
    {
        public ProductProvider()
        {
            this.Db = new MatterspaceDbContext();
        }

        public MatterspaceDbContext Db { get; }

        /// <summary>
        /// Returns the base ViewModel for the given tab
        /// </summary>
        /// <param name="name"></param>
        /// <param name="activeTab"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductViewModel(string name, ProductActiveTab activeTab)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var product = await this.Db.Products.FirstAsync(m => m.Name == name);

            return new ProductViewModel()
            {
                Name = product.Name,
                DisplayName = product.DisplayName,
                ShortDescription = product.ShortDescription,
                WebsiteUrl = product.WebsiteUrl,
                ActiveTab = activeTab
            };
        }

        protected override void Dispose(bool disposing)
        {
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
}