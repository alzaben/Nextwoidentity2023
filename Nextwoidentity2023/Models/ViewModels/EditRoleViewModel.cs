using System.ComponentModel.DataAnnotations;

namespace Nextwoidentity2023.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string? RoleId { get; set; }
        [Required(ErrorMessage ="Enter name")]
        public string? RoleName { get; set; }
        public List<string>? Users { get; set; }

    }
}
