using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Entities
{
    public class ThreadRelease
    {
        public int Id { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public int ReleaseId { get; set; }

        public Release Release { get; set; }
    }
}
