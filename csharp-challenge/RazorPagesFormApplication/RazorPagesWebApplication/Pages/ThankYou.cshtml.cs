using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebApplication.Pages
{
    public class ThankYouModel : PageModel
    {
        public int UserId;

        public void OnGet()
        {
        }       

        public void OnGetSignupId(int signinId)
        {
            UserId = signinId;
        }
    }
}
