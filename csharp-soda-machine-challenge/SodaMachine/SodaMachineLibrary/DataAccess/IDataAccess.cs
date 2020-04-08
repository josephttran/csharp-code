using System.Collections.Generic;
using SodaMachineLibrary.Models;

namespace SodaMachineLibrary.DataAccess
{
    public interface IDataAccess
    {
        void CoinInventoryAddCoins(List<CoinModel> coins);
        List<CoinModel> CoinInventoryGetAll();
        List<CoinModel> CoinInventoryWithdrawCoins(decimal coinValue, int quantity);
        decimal MachineInfoCashOnHand();
        decimal MachineInfoEmptyCash();
        decimal MachineInfoSodaPrice();
        decimal MachineInfoTotalIncome();
        void SodaInventoryAddSodas(List<SodaModel> sodas);
        List<SodaModel> SodaInventoryGetAll();
        SodaModel SodaInventoryGetSoda(SodaModel soda);
        List<SodaModel> SodaInventoryGetTypes();
        void UserCreditClear(string userId);
        void UserCreditDeposit(string userId);
        void UserCreditInsert(string userId, decimal amount);
        decimal UserCreditTotal(string userId);
    }
}