using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Lib.Helpers
{
    /// <summary>
    /// Helpers for the title
    /// </summary>
    public static class TitleHelper
    {
        /// <summary>
        /// Gets the formatted title for a product tab
        /// </summary>
        /// <param name="tabDisplayName"></param>
        /// <param name="productDisplayName"></param>
        /// <returns></returns>
        public static string GetProductTabTitle(string tabDisplayName, string productDisplayName)
        {
            if (tabDisplayName == null) throw new ArgumentNullException(nameof(tabDisplayName));
            if (productDisplayName == null) throw new ArgumentNullException(nameof(productDisplayName));

            return $"{tabDisplayName} · {productDisplayName}";
        }
    }
}