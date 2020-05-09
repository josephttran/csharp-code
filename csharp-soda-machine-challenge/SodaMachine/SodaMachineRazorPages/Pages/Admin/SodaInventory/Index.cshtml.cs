using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Models;

namespace SodaMachineRazorPages.Pages.Admin.SodaInventory
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;

        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public string Message { get; set; }
        public string SelectedSoda { get; set; }
        public string SelectedSodaQuantity { get; set; }
        public SelectList Sodas { get; set; }
        public SelectList SodaAddList { get; set; }
        public Dictionary<string, int> SodaQuantity { get; set; }

        public IActionResult OnGet()
        {
            SodaQuantity = new Dictionary<string, int>();

            List<SodaModel> sodaInventory = _dataAccess.SodaInventoryGetAll();

            foreach (SodaModel sodaModel in sodaInventory)
            {
                string sodaKey = $"{ sodaModel.Name } { sodaModel.SlotOccupied }";

                if (SodaQuantity.ContainsKey(sodaKey))
                {
                    SodaQuantity[sodaKey]++;
                }
                else
                {
                    SodaQuantity[sodaKey] = 1;
                }
            }

            return Page();
        }

        public IActionResult OnPostAddSoda()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return OnGet();
        }
    }
}
