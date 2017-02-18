using System.Web.Mvc;
using Matterspace.Models;
using Matterspace.Model;
using Matterspace.Lib.Services.Product;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

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

        public async Task<ActionResult> Index()
        {
            if (!this.Request.IsAuthenticated)
                return this.View("Index.NotAuthenticated");

            var userId = ((ClaimsPrincipal)HttpContext.User).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                throw new HttpRequestValidationException("User id not found in Claims.");
            }

            var products = await _productService.GetProductsByMember(userId.Value);

            // the user is authenticated
            var indexViewModel = new IndexViewModel
            {
                Products = products
            };

            return this.View("Index", indexViewModel);
        }
    }
}