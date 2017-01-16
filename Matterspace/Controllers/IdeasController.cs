﻿using Matterspace.Lib.Helpers;
using Matterspace.Lib.Providers.Product;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class IdeasController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index(string productName)
        {
            var viewModel = await new ProductProvider().GetProductViewModel(productName, ProductActiveTab.Ideas);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Ideas", viewModel.DisplayName);
            return this.View(viewModel);
        }
    }
}