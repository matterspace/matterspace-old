using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Matterspace.Lib.Helpers;
using Matterspace.Model;
using Matterspace.Models;
using Matterspace.Lib.Services.Product;

namespace Matterspace.Controllers
{
    public class ProductsController : Controller
    {
        public MatterspaceDbContext Db { get; }

        private readonly ProductService _productService;

        public ProductsController()
        {
            this.Db = new MatterspaceDbContext();
            this._productService = new ProductService(this.Db);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateProductViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductViewModel formModel)
        {
            if (!this.ModelState.IsValid)
                return this.View(formModel);

            if(string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                throw new InvalidOperationException("User not found.");
            }

            formModel.UserName = HttpContext.User.Identity.Name;
            await this._productService.CreateProduct(formModel);
            return this.RedirectToRoute(RouteConfig.PRODUCT_HOME, new { productName = formModel.Name });
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            if (productName == null) throw new ArgumentNullException(nameof(productName));

            var viewModel = await this._productService.GetProductViewModel(productName, ProductActiveTab.Home);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Home", viewModel.DisplayName);

            return this.View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
}