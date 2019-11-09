using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesWebApplication.Models;

namespace RazorPagesWebApplication.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }
    }
}
