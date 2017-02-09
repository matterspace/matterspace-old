using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public SettingsViewModel()
        {
            this.Result = new OperationResult();
        }

        public SettingsActiveTab ActiveTab { get; set; }

        public ProductViewModel Product { get; set; }

        public string UserNameToAddId { get; set; }

        [Required]
        [DisplayName("Add an user to this project")]
        public string UserNameToAdd { get; set; }

        public OperationResult Result { get; set; }
    }
}