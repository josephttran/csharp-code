using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SodaMachineLibrary.DataAccess;

namespace SodaMachineRazorPages.Pages.Admin.Income
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;

        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [BindProperty]
        public decimal CurrentIncome { get; set; }
        [BindProperty]
        public decimal TotalIncome { get; set; }

        public IActionResult OnGet()
        {
            CurrentIncome = _dataAccess.MachineInfoCashOnHand();
            TotalIncome = _dataAccess.MachineInfoTotalIncome();

            return Page();
        }

        public IActionResult OnPostEmptyMachine()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return OnGet();
        }
    }
}
