using Matterspace.Controllers.Thread;
using Matterspace.Lib.Helpers;
using Matterspace.Lib.Services.Product;
using Matterspace.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using Matterspace.Model.Enums;

namespace Matterspace.Controllers
{
    public class QAController : ThreadController
    {
        protected override ProductActiveTab ActiveTab
        {
            get
            {
                return ProductActiveTab.QA;
            }
        }

        protected override ThreadType ThreadType
        {
            get
            {
                return ThreadType.QA;
            }
        }
    }
}