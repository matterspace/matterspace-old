using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public enum SettingsActiveTab
    {
        Settings,
        Members,
        Integrations
    }

    public class SettingsViewModel
    {
        public SettingsActiveTab ActiveTab { get; set; }

        public ProductViewModel Product { get; set; }
    }
}