using Matterspace.Controllers.Thread;
using Matterspace.Models;
using Matterspace.Model.Enums;

namespace Matterspace.Controllers
{
    public class DocsController : ThreadController
    {
        protected override ProductActiveTab ActiveTab => ProductActiveTab.Docs;

        protected override ThreadType TabType => ThreadType.Doc;
    }
}