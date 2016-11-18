using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Matterspace.Models;

namespace Matterspace.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Create()
        {
            var viewModel = new CreateProductViewModel();
            return View(viewModel);
        }
    }
}