﻿using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace Matterspace.Controllers
{
    public class ReleasesController : ThreadController
    {
        protected override ProductActiveTab ActiveTab
        {
            get
            {
                return ProductActiveTab.Releases;
            }
        }

        protected override ThreadType TabType
        {
            get
            {
                return ThreadType.QA;
            }
        }
    }
}