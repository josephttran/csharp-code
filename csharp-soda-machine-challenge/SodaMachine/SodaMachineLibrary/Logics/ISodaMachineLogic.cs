using System.Collections.Generic;
using SodaMachine.Models;

namespace SodaMachine.Logics
{
    public interface ISodaMachineLogic
    {
        void AddToCoinInventory(List<CoinModel> coins);
        void AddToSodaInventory(List<SodaModel> sodas);
        decimal EmptyMoneyFromMachine();
        List<CoinModel> GetCoinInventory();
        decimal GetCurrentIncome();
        decimal GetMoneyInsertedTotal(string userId);
        List<SodaModel> GetSodaInventory();
        decimal GetSodaPrice();
        decimal GetTotalIncome();
        decimal IssueFullRefund();
        List<SodaModel> ListTypesOfSoda();
        decimal MoneyInserted(string userId, decimal amount);
        (SodaModel soda, List<CoinModel> coins, string message) RequestSoda(SodaModel soda);
    }
}