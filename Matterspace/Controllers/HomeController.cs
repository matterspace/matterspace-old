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
        private readonly MatterspaceDbContext _database;
        private readonly ProductService _productService;

        public HomeController()
        {
            _database = new MatterspaceDbContext();
            _productService = new ProductService(_database);
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var userId = UserHelper.GetUserIdFromClaims(HttpContext);
            var products = await _productService.GetProductsByMember(userId);

            // the user is authenticated
            var indexViewModel = new IndexViewModel
            {
                Products = products
            };

            return this.View("Index", indexViewModel);
        }
    }
}