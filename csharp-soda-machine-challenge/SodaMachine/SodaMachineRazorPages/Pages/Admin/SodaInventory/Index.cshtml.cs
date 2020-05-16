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
        [BindProperty]
        public string SelectedSoda { get; set; }
        [BindProperty]
        public string SelectedSodaQuantity { get; set; }
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

            SodaAddList = new SelectList(SodaQuantity, "Key", "Key");

            return Page();
        }

        public IActionResult OnPostAddSoda()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(SelectedSoda))
            {
                Message = "Please select soda with slot";
            }
            else
            {
                if (int.TryParse(SelectedSodaQuantity, out int quantity))
                {
                    if (quantity > 0 && quantity < 10)
                    {
                        List<SodaModel> sodas = new List<SodaModel>();
                        string[] sodaNameSlot = SelectedSoda.Split(" ");

                        for (int i = 0; i < quantity; i++)
                        {
                            SodaModel sodaModel = new SodaModel
                            {
                                Name = sodaNameSlot[0],
                                SlotOccupied = sodaNameSlot[1]
                            };

                            sodas.Add(sodaModel);
                        }

                        _dataAccess.SodaInventoryAddSodas(sodas);

                        Message = $"Successfully added { quantity } { sodaNameSlot[0] } at slot { sodaNameSlot[1] }";
                    }
                    else
                    {
                        Message = "Quantity must be greater than 0 and less than 10";
                    }
                }
                else
                {
                    Message = "Please enter a number for quantity";
                }
            }

            return OnGet();
        }
    }
}
