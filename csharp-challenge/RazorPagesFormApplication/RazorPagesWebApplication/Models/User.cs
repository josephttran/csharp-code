using System.ComponentModel.DataAnnotations;

namespace RazorPagesWebApplication.Models
{
    public class User
    {
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
