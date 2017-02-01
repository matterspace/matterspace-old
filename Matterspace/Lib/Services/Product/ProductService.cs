using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Lib.Services.Product
{
    public class ProductService
    {
        public ThreadService ThreadService { get; }

        public ProductService(MatterspaceDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            this.Db = db;
            this.ThreadService = new ThreadService(this.Db);
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
                Id = product.Id,
                Name = product.Name,
                DisplayName = product.DisplayName,
                ShortDescription = product.ShortDescription,
                WebsiteUrl = product.WebsiteUrl,
                FacebookUrl = product.FacebookUrl,
                TwitterUrl = product.TwitterUrl,
                ActiveTab = activeTab,
                ThreadsCount = await this.ThreadService.GetThreadsCount(product.Id)
            };
        }

        public async Task SaveProduct(ProductViewModel viewModel)
        {
            Model.Entities.Product product = null;

            if (viewModel.Id.HasValue)
                product = await this.Db.Products.FindAsync(viewModel.Id.Value);
            else
                product = new Model.Entities.Product();

            product.Name = viewModel.Name.ToLower();
            product.DisplayName = viewModel.DisplayName;
            product.ShortDescription = viewModel.ShortDescription;
            product.WebsiteUrl = viewModel.WebsiteUrl;
            product.TwitterUrl = viewModel.TwitterUrl;
            product.FacebookUrl = viewModel.FacebookUrl;
            
            if (!viewModel.Id.HasValue)
                this.Db.Products.Add(product);

            await this.Db.SaveChangesAsync();
        }
    }
}
