using Matterspace.Controllers.Thread;
using Matterspace.Models;
using Matterspace.Model.Enums;

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

        protected override ThreadType ThreadType
        {
            get
            {
                return ThreadType.QA;
            }
        }
    }
}