using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesWithAdminPages.Data;
using RazorPagesWithAdminPages.Models;

namespace RazorPagesWithAdminPages
{
    public class AdminCreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminCreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var adminPages = _context.AdminPage.Select(x => x.UserId);
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => !adminPages.Contains(x.Id)), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public AdminPage AdminPage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdminPage.Add(AdminPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Admin");
        }
    }
}
