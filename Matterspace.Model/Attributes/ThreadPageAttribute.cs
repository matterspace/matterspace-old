using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ThreadPageAttribute : Attribute
    {
        public string ThreadPageName { get; private set; }

        public ThreadPageAttribute(string threadPageName)
        {
            this.ThreadPageName = threadPageName;
        }
    }
}
