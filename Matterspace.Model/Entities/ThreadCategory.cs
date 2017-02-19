using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Entities
{
    public class ThreadCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ThreadType ThreadType { get; set; }
    }
}
