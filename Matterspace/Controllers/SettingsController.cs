using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Model;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class SettingsController : Controller
    {
        public MatterspaceDbContext Db { get; }

        private ProductService productService;

        public SettingsController()
        {
            this.Db = new MatterspaceDbContext();
            this.productService = new ProductService(this.Db);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.productService.GetProductViewModel(productName, ProductActiveTab.Home);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Settings", viewModel.DisplayName);

            return this.View(viewModel);
        }
    }
}