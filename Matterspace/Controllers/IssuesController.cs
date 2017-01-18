using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class IssuesController : ThreadController
    {
        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.productService.GetProductViewModel(productName, ProductActiveTab.Issues);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Issues", viewModel.DisplayName);
            return this.View(viewModel);
        }
    }
}