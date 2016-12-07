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

                return this.RedirectToAction("Details", new {name = product.Name});
            }

            return View(formModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(string name)
        {
            var product = await this.Db.Products.FirstAsync(m => m.Name == name);

            var viewModel = new ProductViewModel()
            {
                Name = product.Name,
                DisplayName = product.DisplayName,
                ShortDescription = product.ShortDescription,
                WebsiteUrl = product.WebsiteUrl
            };

            return this.View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
}