using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.Settings;
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

        private SettingsService settingsService;
        private ProductService productService;

        public SettingsController()
        {
            this.Db = new MatterspaceDbContext();
            this.settingsService = new SettingsService(this.Db);
            this.productService = new ProductService(this.Db);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);
            viewModel.ActiveTab = SettingsActiveTab.Settings;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(string productName, SettingsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await this.productService.SaveProduct(viewModel.Product);
                return this.RedirectToRoute(RouteConfig.PRODUCT_HOME, new { productName = viewModel.Product.Name });
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Members(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);
            viewModel.ActiveTab = SettingsActiveTab.Members;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddMember(string productName, SettingsViewModel viewModel)
        {
            await this.settingsService.AddMemberToProject(viewModel.UserNameToAdd, viewModel.Product.Id.Value, viewModel.UserNameToAddId);
            return this.RedirectToRoute(RouteConfig.PRODUCT_ACTIONS, new { productName = productName, controller = "Settings", action = "Members" });
        }

        private async Task<SettingsViewModel> GetSettingsViewModel(string productName)
        {
            var product = await this.productService.GetProductViewModel(productName, ProductActiveTab.Home);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Settings", product.DisplayName);

            var viewModel = new SettingsViewModel()
            {
                Product = product
            };

            return viewModel;
        }
    }
}