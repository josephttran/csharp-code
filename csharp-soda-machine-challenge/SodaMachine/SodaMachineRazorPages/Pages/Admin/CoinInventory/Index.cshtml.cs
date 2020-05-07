using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Models;

namespace SodaMachineRazorPages.Pages.Admin.CoinInventory
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;

        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<CoinModel> CoinInventory { get; set; }
        public Dictionary<string, int> CoinsQuantity { get; set; }

        public void OnGet()
        {
            CoinInventory = _dataAccess.CoinInventoryGetAll();

            if (CoinInventory != null)
            {
                CoinsQuantity = new Dictionary<string, int>();

                foreach (CoinModel coin in CoinInventory)
                {
                    if (CoinsQuantity.ContainsKey(coin.Name))
                    {
                        CoinsQuantity[coin.Name]++;
                    }
                    else
                    {
                        CoinsQuantity[coin.Name] = 1;
                    }
                }
            }
        }
    }
}
