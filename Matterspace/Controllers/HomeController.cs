using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.Request.IsAuthenticated ? this.View() : this.View("Index.NotAuthenticated");
        }
    }
}