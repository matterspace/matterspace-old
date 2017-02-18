using System.Web.Mvc;
using Matterspace.Models;
using Matterspace.Model;
using Matterspace.Lib.Services.Product;
using System.Threading.Tasks;
using Matterspace.Lib.Helpers;

namespace Matterspace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController()
        {
            var database = new MatterspaceDbContext();
            this._productService = new ProductService(database);
        }
        
        public async Task<ActionResult> Index()
        {
            if (!this.Request.IsAuthenticated)
                return this.View("Index.NotAuthenticated");

            var userId = UserHelper.GetUserIdFromClaims(this.HttpContext);
            var products = await this._productService.GetProductsByMember(userId);

            // the user is authenticated
            var indexViewModel = new IndexViewModel
            {
                Products = products
            };

            return this.View("Index", indexViewModel);
        }
    }
}