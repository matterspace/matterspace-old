using System.Threading.Tasks;
using System.Web.Mvc;
using Matterspace.Lib.Helpers;
using Matterspace.Model;
using Matterspace.Model.Entities;
using Matterspace.Models;
using Matterspace.Lib.Services.Product;

namespace Matterspace.Controllers
{
    public class ProductsController : Controller
    {
        public MatterspaceDbContext Db { get; }

        private ProductService productService;

        public ProductsController()
        {
            this.Db = new MatterspaceDbContext();
            this.productService = new ProductService(this.Db);
        }

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
                    WebsiteUrl = formModel.WebsiteUrl,
                    TwitterUrl = formModel.TwitterUrl,
                    FacebookUrl = formModel.FacebookUrl
                };

                this.Db.Products.Add(product);
                await this.Db.SaveChangesAsync();

                return this.RedirectToRoute(RouteConfig.PRODUCT_HOME, new { productName = product.Name });
            }

            return View(formModel);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.productService.GetProductViewModel(productName, ProductActiveTab.Home);
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