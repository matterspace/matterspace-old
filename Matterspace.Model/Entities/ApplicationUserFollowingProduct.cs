using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Entities
{
    public class ApplicationUserFollowingProduct
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime StartedAt { get; set; }
    }
}
