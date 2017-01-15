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
    public class IssuesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index(string name)
        {
            var viewModel = await new ProductProvider().GetProductViewModel(name, ProductActiveTab.Issues);
            this.ViewBag.Title = TitleHelper.GetProductTabTitle("Issues", viewModel.DisplayName);
            return this.View(viewModel);
        }
    }
}