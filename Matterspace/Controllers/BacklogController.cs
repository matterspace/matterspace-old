﻿using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace Matterspace.Controllers
{
    public class BacklogController : ThreadController
    {
        protected override ProductActiveTab ActiveTab
        {
            get
            {
                return ProductActiveTab.Backlog;
            }
        }

        protected override ThreadType TabType
        {
            get
            {
                return ThreadType.BacklogItem;
            }
        }
    }
}