using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreRazorPages.Pages
{
    public class SayHiModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="A name is required")]
        [MinLength(2, ErrorMessage = "Must be  at least 2 characters")]
        public string PersonName { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
        }
    }
}