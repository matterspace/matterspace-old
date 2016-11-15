using System.Web.Mvc;
using Matterspace.Models;

namespace Matterspace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!this.Request.IsAuthenticated)
                return this.View("Index.NotAuthenticated");

            // the user is authenticated
            var indexViewModel = new IndexViewModel();
            return this.View("Index", indexViewModel);
        }
    }
}