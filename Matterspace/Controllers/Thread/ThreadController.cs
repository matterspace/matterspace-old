﻿using System;
using System.Diagnostics;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Matterspace.Controllers.Thread
{
    public abstract class ThreadController : Controller
    {
        protected MatterspaceDbContext Db { get; }

        protected ProductService ProductService;
        protected ThreadService ThreadService;

        protected abstract ProductActiveTab ActiveTab { get; }
        protected abstract ThreadType ThreadType { get; }

        protected ThreadController()
        {
            this.Db = new MatterspaceDbContext();
            this.ProductService = new ProductService(this.Db);
            this.ThreadService = new ThreadService(this.Db);
        }

        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await this.GetProductViewModel(productName);

            Debug.Assert(viewModel.Id != null, "viewModel.Id != null");
            viewModel.Threads = await this.ThreadService.GetThreads(viewModel.Id.Value, this.TabType);

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
            if (this.ModelState.IsValid)
            {
                await this.ThreadService.SaveThread(viewModel);
                return this.RedirectToAction("Index");
            }

            return this.View("EditThread", viewModel);
        }

        /// <summary>
        /// Returns a product view model according to the given product name
        /// </summary>
        protected virtual async Task<ProductViewModel> GetProductViewModel(string productName)
        {
            if (productName == null) throw new ArgumentNullException(nameof(productName));

            var viewModel = await this.ProductService.GetProductViewModel(productName, this.ActiveTab);
            return viewModel;
        }

        /// <summary>
        /// Returns a thread view model. If an id is passed, it'll return the given id's information
        /// </summary>
        protected virtual async Task<ThreadViewModel> GetThreadViewModel(string productName, int? id)
        {
            var viewModel = new ThreadViewModel
            {
                Type = this.ThreadType,
                Product = await this.GetProductViewModel(productName)
            };

            if (id.HasValue)
                viewModel = await this.ThreadService.GetThread(id.Value);

            return viewModel;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Db.Dispose();
        }
    }
}