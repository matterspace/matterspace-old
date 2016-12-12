using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Matterspace.Model;
using Matterspace.Model.Entities;
using Matterspace.Models;

namespace Matterspace.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController()
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
        private async Task<ProductViewModel> GetBaseViewModel(string name, ProductActiveTab activeTab)
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

        // GET: Products
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateProductViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(CreateProductViewModel formModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = formModel.Name.ToLower(),
                    DisplayName = formModel.DisplayName,
                    ShortDescription = formModel.ShortDescription,
                    WebsiteUrl = formModel.WebsiteUrl
                };

                this.Db.Products.Add(product);
                await this.Db.SaveChangesAsync();

                return this.RedirectToAction("Index", new {name = product.Name});
            }

            return View(formModel);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Home);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Ideas(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Ideas);
            return this.View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
}