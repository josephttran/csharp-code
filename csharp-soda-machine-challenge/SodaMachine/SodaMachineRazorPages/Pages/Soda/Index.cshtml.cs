using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SodaMachineLibrary.Logics;
using SodaMachineLibrary.Models;

namespace SodaMachineRazorPages.Pages.Soda
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ISodaMachineLogic _sodaMachineLogic;

        public List<decimal> AcceptedCoinsValue { get; set; }
        public decimal ChangeReturned { get; set; }
        public string RequestSodaMessage { get; set; }
        [BindProperty]
        public decimal SelectedCoinValue { get; set; }
        [BindProperty]
        public string SelectedSodaIndex { get; set; }
        public decimal SodaPrice { get; set; }
        public List<SodaModel> SodasInStock { get; set; }
        public List<SelectListItem> SodaSelectList { get; set; }
        public List<SodaModel> TypesOfSoda { get; set; }
        [BindProperty]
        public string UserId { get; set; }
        public decimal UserCredit { get; set; }

        public IndexModel(ISodaMachineLogic sodaMachineLogic)
        {
            _sodaMachineLogic = sodaMachineLogic;
        }

        public IActionResult OnGet()
        {
            ViewData["Title"] = "Soda";
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AcceptedCoinsValue = _sodaMachineLogic.AcceptedCoinValues;
            SodaPrice = _sodaMachineLogic.GetSodaPrice();
            SodasInStock = _sodaMachineLogic.GetSodaInventory();
            TypesOfSoda = _sodaMachineLogic.ListTypesOfSoda();
            UserCredit = _sodaMachineLogic.GetMoneyInsertedTotal(UserId);

            SodaSelectList = SodasInStock.Select((sodaModel, index) =>
            {
                return new SelectListItem($"{sodaModel.Name} {sodaModel.SlotOccupied}", index.ToString());
            }).ToList();

            return Page();
        }

        public IActionResult OnPostDepositCoins()
        {
            AcceptedCoinsValue = _sodaMachineLogic.AcceptedCoinValues;

            if (AcceptedCoinsValue.Contains(SelectedCoinValue))
            {
                _sodaMachineLogic.MoneyInserted(UserId, SelectedCoinValue);

                UserCredit = _sodaMachineLogic.GetMoneyInsertedTotal(UserId);
            }

            return OnGet();
        }

        public IActionResult OnPostEjectMoneyInserted()
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ChangeReturned = _sodaMachineLogic.IssueFullRefund(UserId);

            return OnGet();
        }

        public IActionResult OnPostRequestSoda()
        {
            if (int.TryParse(SelectedSodaIndex, out int sodaIndex))
            {
                SodasInStock = _sodaMachineLogic.GetSodaInventory();

                if (sodaIndex > -1 && sodaIndex < SodasInStock.Count)
                {
                    SodaModel requestSoda = SodasInStock[sodaIndex];

                    var (soda, coins, message) = _sodaMachineLogic.RequestSoda(requestSoda);

                    RequestSodaMessage = message;

                    if (coins.Count > 0)
                    {
                        decimal change = 0;

                        foreach (CoinModel coin in coins)
                        {
                            change += coin.Amount;
                        }

                        ChangeReturned = change;
                    }
                }
                else
                {
                    RequestSodaMessage = "Please select a soda";
                }
            }
            else 
            { 
                RequestSodaMessage = "Please select a soda";
            }

            return OnGet();
        }
    }
}
