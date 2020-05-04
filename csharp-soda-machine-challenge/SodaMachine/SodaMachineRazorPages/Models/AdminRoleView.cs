using System.ComponentModel.DataAnnotations;

namespace SodaMachineRazorPages.Models
{
    public class AdminRoleView
    {
        public string Email { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
