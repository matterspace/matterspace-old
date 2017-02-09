using Matterspace.Controllers.Thread;
using Matterspace.Model.Enums;
using Matterspace.Models;

namespace Matterspace.Controllers
{
    public class IssuesController : ThreadController
    {
        protected override ProductActiveTab ActiveTab => ProductActiveTab.Issues;

        protected override ThreadType ThreadType => ThreadType.Issue;
    }
}