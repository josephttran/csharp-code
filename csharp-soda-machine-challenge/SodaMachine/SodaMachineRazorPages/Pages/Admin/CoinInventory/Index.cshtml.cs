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

namespace SodaMachineRazorPages.Pages.Admin.CoinInventory
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;

        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            Coins = new Dictionary<string, decimal>
            {
                { "Quarter", 0.25M },
                { "Dollar", 1.00M }
            };
        }

        public Dictionary<string, decimal> Coins { get; set; }
        public List<CoinModel> CoinInventory { get; set; }
        public Dictionary<string, int> CoinsQuantity { get; set; }
        public SelectList CoinAddList { get; set; }
        public string Message { get; set; }

        [BindProperty]
        public string SelectedCoin { get; set; }

        [BindProperty]
        public string SelectedCoinQuantity { get; set; }

        public IActionResult OnGet()
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

            CoinAddList = new SelectList(Coins, "Key", "Key");

            return Page();
        }

        public IActionResult OnPostAddCoin()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (!string.IsNullOrEmpty(SelectedCoin))
                {
                    if (int.TryParse(SelectedCoinQuantity, out int quantity))
                    {
                        if (quantity > 0 && quantity < 40)
                        {
                            CoinModel coin = new CoinModel
                            {
                                Amount = Coins[SelectedCoin],
                                Name = SelectedCoin
                            };

                            List<CoinModel> coinsToAdd = new List<CoinModel>();

                            for (int i = 0; i < quantity; i++)
                            {
                                coinsToAdd.Add(coin);
                            }

                            _dataAccess.CoinInventoryAddCoins(coinsToAdd);


                            Message = $"Successfully added {quantity} {SelectedCoin}";
                        }
                        else
                        {
                            Message = "Number must be greater than 0 and less than 40";
                        }
                    }
                    else
                    {
                        Message = "Enter a number in quantity";
                    }
                }
                else
                {
                    Message = "Please select a coin";
                }
            }

            return OnGet();
        }
    }
}
