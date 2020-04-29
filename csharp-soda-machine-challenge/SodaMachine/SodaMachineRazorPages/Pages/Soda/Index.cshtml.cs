using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SodaMachineLibrary.Logics;
using SodaMachineLibrary.Models;

namespace SodaMachineRazorPages.Pages.Soda
{
    public class IndexModel : PageModel
    {
        private readonly ISodaMachineLogic _sodaMachineLogic;

        public List<decimal> AcceptedCoinValues { get; set; }
        public decimal ChangeReturned { get; set; }
        public string RequestSodaMessage { get; set; }
        public decimal SelectedCoinValue { get; set; }
        public SodaModel SelectedSoda { get; set; }
        public decimal SodaPrice { get; set; }
        public List<SodaModel> SodasInStock { get; set; }
        public List<SodaModel> TypesOfSoda { get; set; }
        public string UserId { get; set; }
        public decimal UserCredit { get; set; }

        public IndexModel(ISodaMachineLogic sodaMachineLogic)
        {
            _sodaMachineLogic = sodaMachineLogic;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Soda";

            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Initialize();
        }

        public void OnPostDepositCoins()
        {
            if (AcceptedCoinValues.Contains(SelectedCoinValue))
            {
                _sodaMachineLogic.MoneyInserted(UserId, SelectedCoinValue);

                UserCredit = _sodaMachineLogic.GetMoneyInsertedTotal(UserId);
            }
        }

        public void OnPostEjectMoneyInserted()
        {
            ChangeReturned = _sodaMachineLogic.IssueFullRefund(UserId);
            UserCredit = 0;
        }

        public void OnPostRequestSoda()
        {
            if (SelectedSoda != null)
            {
                var (soda, coins, message) = _sodaMachineLogic.RequestSoda(SelectedSoda);

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
                RequestSodaMessage = "No soda selected";
            }
        }

        private void Initialize()
        {
            AcceptedCoinValues = _sodaMachineLogic.AcceptedCoinValues;
            SelectedCoinValue = 0;
            SodaPrice = _sodaMachineLogic.GetSodaPrice();
            SodasInStock = _sodaMachineLogic.GetSodaInventory();
            TypesOfSoda = _sodaMachineLogic.ListTypesOfSoda();
            UserCredit = _sodaMachineLogic.GetMoneyInsertedTotal(UserId);
        }
    }
}
