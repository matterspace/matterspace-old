using System.Web.Mvc;
using Matterspace.Models;
using Matterspace.Model;
using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.User;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Matterspace.Controllers
{
    public class HomeController : Controller
    {
        private readonly MatterspaceDbContext _database;
        private readonly ProductService _productService;
        private UserService _userService;

        public HomeController()
        {
            _database = new MatterspaceDbContext();
            _productService = new ProductService(_database);
        }

        public async Task<ActionResult> Index()
        {
            if (!this.Request.IsAuthenticated)
                return this.View("Index.NotAuthenticated");

            //I need initialize service here because HttpContext is null in constructor.
            _userService = new UserService(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());

            var user = await _userService.GetUser(HttpContext.User.Identity.Name);
            var products = await _productService.GetProductsByMember(user.Id);

            // the user is authenticated
            var indexViewModel = new IndexViewModel
            {
                Products = products
            };

            return this.View("Index", indexViewModel);
        }
    }
}