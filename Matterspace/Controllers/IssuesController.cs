using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matterspace.Controllers
{
    public class IssuesController : ThreadController
    {
        protected override ProductActiveTab ActiveTab
        {
            get
            {
                return ProductActiveTab.Issues;
            }
        }

        protected override ThreadType ThreadType
        {
            get
            {
                return ThreadType.Issue;
            }
        }
    }
}