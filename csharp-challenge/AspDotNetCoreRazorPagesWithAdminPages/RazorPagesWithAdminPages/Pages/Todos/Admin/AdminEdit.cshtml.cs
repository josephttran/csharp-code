using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesWithAdminPages.Data;
using RazorPagesWithAdminPages.Models;

namespace RazorPagesWithAdminPages
{
    public class AdminEditModel : PageModel
    {
        private readonly RazorPagesWithAdminPages.Data.ApplicationDbContext _context;

        public AdminEditModel(RazorPagesWithAdminPages.Data.ApplicationDbContext context)
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
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdminPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminPageExists(AdminPage.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Admin");
        }

        private bool AdminPageExists(string id)
        {
            return _context.AdminPage.Any(e => e.UserId == id);
        }
    }
}
