using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.Settings;
using Matterspace.Model;
using Matterspace.Models;
using System.Threading.Tasks;
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


        /// <summary>
        /// Settings page
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);

            viewModel.ActiveTab = SettingsActiveTab.Settings;

            return this.View(viewModel);
        }

        /// <summary>
        /// Saves the default settings for a product
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Save(string productName, SettingsViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                await this.productService.SaveProduct(viewModel.Product);
                return this.RedirectToRoute(RouteConfig.PRODUCT_HOME, new { productName = viewModel.Product.Name });
            }

            return this.View(viewModel);
        }

        /// <summary>
        /// Members settings page
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Members(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);

            viewModel.ActiveTab = SettingsActiveTab.Members;

            return this.View(viewModel);
        }

        /// <summary>
        /// Add member to a product in settings
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddMember(string productName, SettingsViewModel viewModel)
        {
            var saveResult = await this.productService.AddMemberToProduct(viewModel.UserNameToAdd, viewModel.Product.Id.Value, viewModel.UserNameToAddId);

            var settingsViewModel = await this.GetSettingsViewModel(productName);
            settingsViewModel.ActiveTab = SettingsActiveTab.Members;

            settingsViewModel.Result = saveResult;

            return this.View("Members", settingsViewModel);
        }

        /// <summary>
        /// Remove a member to a product in settings
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> RemoveMember(string productName, string id)
        {
            var removeResult = await this.productService.RemoveMemberFromProduct(id, productName);

            var settingsViewModel = await this.GetSettingsViewModel(productName);
            settingsViewModel.ActiveTab = SettingsActiveTab.Members;

            settingsViewModel.Result = removeResult;

            return this.View("Members", settingsViewModel);
        }

        /// <summary>
        /// Categories settings page
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Categories(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);

            viewModel.ActiveTab = SettingsActiveTab.Categories;

            return this.View(viewModel);
        }

        /// <summary>
        /// Integrations settings page
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Integrations(string productName)
        {
            var viewModel = await this.GetSettingsViewModel(productName);

            viewModel.ActiveTab = SettingsActiveTab.Integrations;

            return this.View(viewModel);
        }

        private async Task<SettingsViewModel> GetSettingsViewModel(string productName)
        {
            var product = await this.productService.GetProductViewModel(productName, ProductActiveTab.Settings);
            product.Members = await this.productService.GetMembersInProduct(product.Id.Value);

            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Settings", product.DisplayName);

            var viewModel = new SettingsViewModel()
            {
                Product = product
            };

            return viewModel;
        }
    }
}