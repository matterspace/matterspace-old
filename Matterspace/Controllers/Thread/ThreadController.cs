﻿using Matterspace.Lib.Services.Product;
using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
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

        protected ThreadController()
        {
            this.Db = new MatterspaceDbContext();
            this.productService = new ProductService(this.Db);
            this.threadService = new ThreadService(this.Db);
        }

        [HttpGet]
        public virtual async Task<ActionResult> New(string productName)
        {
            return await this.Edit(productName, null);
        }

        public virtual async Task<ActionResult> Edit(string productName, int? id)
        {
            var viewModel = await this.productService.GetProductViewModel(productName, ProductActiveTab.Ideas);
            viewModel.Thread = new ThreadViewModel();

            if (id.HasValue)
                viewModel.Thread = await this.threadService.GetThreadViewModel(id.Value);

            return this.View("EditThread", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Db.Dispose();
        }
    }
}