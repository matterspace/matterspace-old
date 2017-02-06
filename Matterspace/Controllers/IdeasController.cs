using Matterspace.Controllers.Thread;
using Matterspace.Model.Enums;
using Matterspace.Models;

namespace Matterspace.Controllers
{
    public class IdeasController : ThreadController
    {
        protected override ProductActiveTab ActiveTab => ProductActiveTab.Ideas;

        protected override ThreadType TabType => ThreadType.Idea;
    }
}