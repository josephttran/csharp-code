using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace SodaMachineLibrary.Tests.Mocks
{
    class MockDataAccess : IDataAccess
    {
        public List<CoinModel> CoinInventory { get; set; }
        public (decimal cashOnHand, decimal sodaPrice, decimal totalIncome) MachineInfo { get; set; }
        public List<SodaModel> SodaInventory { get; set; }
        public Dictionary<string, decimal> UserCredit { get; set; }

        public MockDataAccess()
        {
            CoinInventory = new List<CoinModel>()
            {
                new CoinModel { Name = "Quarter", Amount = 0.25M },
                new CoinModel { Name = "Dollar", Amount = 1.00M },
            };

            MachineInfo = (10.00M, 1.00M, 50.00M);

            SodaInventory = new List<SodaModel>()
            {
                new SodaModel { Name = "Pepsi", SlotOccupied = "A1"},
                new SodaModel { Name = "Cola", SlotOccupied = "A2"},
                new SodaModel { Name = "Sprite", SlotOccupied = "B1"},
                new SodaModel { Name = "Mug", SlotOccupied = "B2"},
                new SodaModel { Name = "Cola", SlotOccupied = "D4"},
            };

            UserCredit = new Dictionary<string, decimal>()
            {
                { "1234", 1.50M }
            };
        }

        public void CoinInventoryAddCoins(List<CoinModel> coins) 
        {
            CoinInventory.AddRange(coins);
        }

        public List<CoinModel> CoinInventoryGetAll() 
        {
            return CoinInventory;
        }

        public List<CoinModel> CoinInventoryWithdrawCoins(decimal coinValue, int quantity) 
        {
            return new List<CoinModel>();
        }

        public decimal MachineInfoCashOnHand() 
        {
            return MachineInfo.cashOnHand;
        }

        public decimal MachineInfoEmptyCash() 
        {
            decimal totalCash = MachineInfo.cashOnHand;

            MachineInfo = (0, MachineInfo.sodaPrice, MachineInfo.totalIncome);

            return totalCash;
        }

        public decimal MachineInfoSodaPrice() 
        {
            return MachineInfo.sodaPrice;
        }

        public decimal MachineInfoTotalIncome() 
        {
            return MachineInfo.totalIncome;
        }

        public void SodaInventoryAddSodas(List<SodaModel> sodas) 
        {
            SodaInventory.AddRange(sodas);
        }

        public List<SodaModel> SodaInventoryGetAll() 
        {
            return SodaInventory;
        }

        public SodaModel SodaInventoryGetSoda(SodaModel soda) 
        {
            return SodaInventory.Find(sodaInventorySoda => 
                sodaInventorySoda.Name == soda.Name && 
                sodaInventorySoda.SlotOccupied == soda.SlotOccupied
            );
        }

        public List<SodaModel> SodaInventoryGetTypes() 
        {
            return SodaInventory.GroupBy(x => x.Name).Select(g => g.First()).ToList();
        }

        public void UserCreditClear(string userId) 
        {
            UserCredit[userId] = 0;
        }

        public void UserCreditDeposit(string userId) 
        {
            UserCredit.Add(userId, 0);
        }

        public void UserCreditInsert(string userId, decimal amount) 
        {
            UserCredit[userId] += amount;
        }

        public decimal UserCreditTotal(string userId) 
        {
            return UserCredit[userId];
        }
    }
}
