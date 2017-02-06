using Matterspace.Controllers.Thread;
using Matterspace.Models;
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

        protected override ThreadType TabType
        {
            get
            {
                return ThreadType.QA;
            }
        }
    }
}