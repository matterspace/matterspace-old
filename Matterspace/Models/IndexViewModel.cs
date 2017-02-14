using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Matterspace.Models
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Updates = new List<TimelineUpdateViewModel>();
        }

        /// <summary>
        /// User time-line updates
        /// </summary>
        public IList<TimelineUpdateViewModel> Updates { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }

        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }
}