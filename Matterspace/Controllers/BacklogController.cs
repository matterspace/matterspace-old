using Matterspace.Controllers.Thread;
using Matterspace.Models;
using Matterspace.Model.Enums;

namespace Matterspace.Controllers
{
    public class BacklogController : ThreadController
    {
        protected override ProductActiveTab ActiveTab => ProductActiveTab.Backlog;

        protected override ThreadType ThreadType => ThreadType.BacklogItem;
    }
}