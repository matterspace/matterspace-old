using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Matterspace.Lib.Helpers;
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
        public async Task<ActionResult> Create(CreateProductViewModel formModel)
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
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Home", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Ideas(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Ideas);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Ideas", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Issues(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Issues);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Issues", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Backlog(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Backlog);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Backlog", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> QA(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.QA);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Questions & Answers", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Docs(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Docs);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Documentation", viewModel.DisplayName);
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Releases(string name)
        {
            var viewModel = await this.GetBaseViewModel(name, ProductActiveTab.Releases);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Releases", viewModel.DisplayName);
            return this.View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
}