using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesWithAdminPages.Data;
using RazorPagesWithAdminPages.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesWithAdminPages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AdminPage> AdminPages { get; set; }

        public async Task OnGet()
        {
            AdminPages = await _context.AdminPage.ToListAsync();
        }
    }
}