using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class BacklogItem : Thread
    {
        public BacklogItemStatus BacklogItemStatus;
    }
}
