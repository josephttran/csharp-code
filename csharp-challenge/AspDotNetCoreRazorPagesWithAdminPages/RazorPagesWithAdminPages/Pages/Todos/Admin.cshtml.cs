using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWithAdminPages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}