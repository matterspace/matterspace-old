using System;

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

        /// <summary>
        /// Gets the formatted title for a thread tab
        /// </summary>
        public static string GetThreadTabTitle(string threadTitle, string threadId, string productDisplayName)
        {
            if (threadTitle == null) throw new ArgumentNullException(nameof(threadTitle));
            if (threadId == null) throw new ArgumentNullException(nameof(threadId));
            if (productDisplayName == null) throw new ArgumentNullException(nameof(productDisplayName));

            return $"{threadTitle} · #{threadId} · {productDisplayName}";
        }
    }
}