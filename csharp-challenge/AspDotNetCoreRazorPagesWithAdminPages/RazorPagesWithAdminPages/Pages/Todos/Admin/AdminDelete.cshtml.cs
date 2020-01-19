using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesWithAdminPages.Data;
using RazorPagesWithAdminPages.Models;

namespace RazorPagesWithAdminPages
{
    public class AdminDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminDeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdminPage AdminPage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdminPage = await _context.AdminPage
                .Include(a => a.ApplicationUser).FirstOrDefaultAsync(m => m.UserId == id);

            if (AdminPage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdminPage = await _context.AdminPage.FindAsync(id);

            if (AdminPage != null)
            {
                _context.AdminPage.Remove(AdminPage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Admin");
        }
    }
}
