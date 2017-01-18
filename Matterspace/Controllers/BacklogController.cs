using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class BacklogController : ThreadController
    {
        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await productService.GetProductViewModel(productName, ProductActiveTab.Backlog);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Backlog", viewModel.DisplayName);
            return this.View(viewModel);
        }
    }
}