using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matterspace.Controllers.Thread
{
    public abstract class ThreadController : Controller
    {
        protected MatterspaceDbContext Db { get; }

        protected ProductService productService;
        protected ThreadService threadService;

        protected abstract ProductActiveTab ActiveTab { get; }
        protected abstract ThreadType ThreadType { get; }

        protected ThreadController()
        {
            this.Db = new MatterspaceDbContext();
            this.productService = new ProductService(this.Db);
            this.threadService = new ThreadService(this.Db);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.GetProductViewModel(productName);
            viewModel.Threads = await this.threadService.GetThreads(viewModel.Id.Value, this.ThreadType);

            this.ViewBag.Title = TitleHelper.GetProductTabTitle(viewModel.ActiveTab.ToString(), viewModel.DisplayName);

            return this.View(viewModel);
        }

        [HttpGet]
        public virtual async Task<ActionResult> New(string productName)
        {
            return await this.Edit(productName, null);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(string productName, int? id)
        {
            var viewModel = await this.GetThreadViewModel(productName, id);

            return this.View("EditThread", viewModel);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(ThreadViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await this.threadService.SaveThread(viewModel);
                return RedirectToAction("Index");
            }

            return this.View("EditThread", viewModel);
        }

        /// <summary>
        /// Returns a product view model according to the given product name
        /// </summary>
        protected async virtual Task<ProductViewModel> GetProductViewModel(string productName)
        {
            var viewModel = await this.productService.GetProductViewModel(productName, ActiveTab);
            return viewModel;
        }

        /// <summary>
        /// Returns a thread view model. If an id is passed, it'll return the given id's information
        /// </summary>
        protected async virtual Task<ThreadViewModel> GetThreadViewModel(string productName, int? id)
        {
            var viewModel = new ThreadViewModel()
            {
                Type = ThreadType
            };

            viewModel.Product = await this.GetProductViewModel(productName);

            if (id.HasValue)
                viewModel = await this.threadService.GetThread(id.Value);

            return viewModel;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Db.Dispose();
        }
    }
}