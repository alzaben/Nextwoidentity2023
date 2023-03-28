using System.ComponentModel.DataAnnotations;

namespace Nextwoidentity2023.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
