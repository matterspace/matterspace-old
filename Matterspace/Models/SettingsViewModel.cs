using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public string UserNameToAddId { get; set; }

        [Required]
        [DisplayName("Add an user to this project")]
        public string UserNameToAdd { get; set; }
    }
}