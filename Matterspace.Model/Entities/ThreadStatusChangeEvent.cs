using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Entities
{
    public class ThreadStatusChangeEvent
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime ChangedAt { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }
    }
}
