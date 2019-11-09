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
        private readonly ILogger _logger;

        [BindProperty]
        public new User User { get; set; }

        public SignupModel(ILogger<SignupModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string userInfo = $"User: { User.FirstName }, { User.LastName }, { User.Email }, { User.Password }";

            _logger.LogCritical(userInfo);
        }
    }
}
