using NUnit.Framework;
using SodaMachineLibrary.Logics;
using SodaMachineLibrary.Models;
using SodaMachineLibrary.Tests.Mocks;
using System.Collections.Generic;

namespace SodaMachineLibrary.Tests
{
    [TestFixture]
    public class SodaMachineLogicTests
    {
        SodaMachineLogic sodaMachineLogic;
        MockDataAccess mockDataAccess;

        [SetUp]
        public void Setup()
        {
            mockDataAccess = new MockDataAccess();
            sodaMachineLogic = new SodaMachineLogic(mockDataAccess);
        }

        [Test]
        public void AddToCoinInventory_ShouldWork()
        {
            // Arrange
            int expectedCount;
            int actualCount;
            List<CoinModel> coins = new List<CoinModel>()
            {
                new CoinModel { Name = "Quarter", Amount = 0.25M },
                new CoinModel { Name = "Dollar", Amount = 1.00M }
            };

            // Act
            expectedCount = 2 + mockDataAccess.CoinInventory.Count;
            sodaMachineLogic.AddToCoinInventory(coins);
            actualCount = mockDataAccess.CoinInventory.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddToSodaInventory_ShouldWork()
        {
            int expectedCount;
            int actualCount;
            List<SodaModel> sodas = new List<SodaModel>()
            {
                new SodaModel { Name = "Sprite", SlotOccupied = "B1"},
                new SodaModel { Name = "Mug", SlotOccupied = "B2"}
            };

            expectedCount = 2 + mockDataAccess.SodaInventory.Count;
            sodaMachineLogic.AddToSodaInventory(sodas);
            actualCount = mockDataAccess.SodaInventory.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EmptyMoneyFromMachine_ShouldWork()
        {
            decimal expectedCash;
            decimal actualCash;

            expectedCash = mockDataAccess.MachineInfo.cashOnHand;
            actualCash = sodaMachineLogic.EmptyMoneyFromMachine();

            Assert.AreEqual(expectedCash, actualCash);
        }

        [Test]
        public void GetCoinInventory_ShouldWork()
        {
            List<CoinModel> expectedCoins;
            List<CoinModel> actualCoins;

            expectedCoins = mockDataAccess.CoinInventory;
            actualCoins = sodaMachineLogic.GetCoinInventory();

            CollectionAssert.AreEqual(expectedCoins, actualCoins);
        }

        [Test]
        public void GetCurrentIncome_ShouldWork()
        {
            decimal expectedIncome;
            decimal actualIncome;

            expectedIncome = mockDataAccess.MachineInfo.cashOnHand;
            actualIncome = sodaMachineLogic.GetCurrentIncome();

            Assert.AreEqual(expectedIncome, actualIncome);
        }

        [Test]
        public void GetMoneyInsertedTotal_ShouldWork()
        {
            string userId = "user1234";
            decimal expectedMoneyInsertedTotal;
            decimal actualMoneyInsertedTotal;

            expectedMoneyInsertedTotal = mockDataAccess.UserCredit[userId];
            actualMoneyInsertedTotal = sodaMachineLogic.GetMoneyInsertedTotal(userId);

            Assert.AreEqual(expectedMoneyInsertedTotal, actualMoneyInsertedTotal);
        }

        [Test]
        public void GetSodaInventory_ShouldWork()
        {
            List<SodaModel> expectedSodas;
            List<SodaModel> actualSodas;

            expectedSodas = mockDataAccess.SodaInventory;
            actualSodas = sodaMachineLogic.GetSodaInventory();

            CollectionAssert.AreEqual(expectedSodas, actualSodas);
        }

        [Test]
        public void GetSodaPrice_ShouldWork()
        {
            decimal expectedPrice;
            decimal actualPrice;

            expectedPrice = mockDataAccess.MachineInfo.sodaPrice;
            actualPrice = sodaMachineLogic.GetSodaPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void GetTotalIncome_ShouldWork()
        {
            decimal expectedTotalIncome;
            decimal actualTotalIncome;

            expectedTotalIncome = mockDataAccess.MachineInfo.totalIncome;
            actualTotalIncome = sodaMachineLogic.GetTotalIncome();

            Assert.AreEqual(expectedTotalIncome, actualTotalIncome);
        }

        [Test]
        public void IssueFullRefund_ShouldWork()
        {
            string userId = "user1234";
            decimal expectedRefundAmount;
            decimal actualRefundAmount;

            expectedRefundAmount = sodaMachineLogic.GetMoneyInsertedTotal(userId);
            actualRefundAmount = sodaMachineLogic.IssueFullRefund(userId);

            Assert.AreEqual(expectedRefundAmount, actualRefundAmount);
        }

        [Test]
        public void ListTypesOfSoda_ShouldWork()
        {
            List<SodaModel> expectedTypeOfSodas;
            List<SodaModel> actualTypeOfSodas;

            expectedTypeOfSodas = mockDataAccess.SodaInventoryGetTypes();
            actualTypeOfSodas = sodaMachineLogic.ListTypesOfSoda();

            CollectionAssert.AreEqual(expectedTypeOfSodas, actualTypeOfSodas);
        }

        [Test]
        public void MoneyInserted_SingleUserShouldHaveCorrectAmount()
        {
            string userId = "user789";
            decimal expectedAmount = 0;
            decimal insertedAmount = 0.50M;
            decimal actualAmount;

            sodaMachineLogic.MoneyInserted(userId, insertedAmount);
            actualAmount = mockDataAccess.UserCreditTotal(userId);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void MoneyInserted_User2ShouldHaveCorrectAmount()
        {
            string userId = "user456";
            decimal expectedAmount = 1.50M;
            decimal actualAmount;

            sodaMachineLogic.MoneyInserted(userId, 1.00M);
            sodaMachineLogic.MoneyInserted(userId, 0.25M);
            sodaMachineLogic.MoneyInserted(userId, 0.25M);
            actualAmount = mockDataAccess.UserCreditTotal(userId);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void RequestSoda_ShouldReturnSodaWithChange()
        {
            string userId = "user2468";
            decimal amount = 1.00M;
            SodaModel actualSoda;
            int coinCount;
            SodaModel requestedSoda = new SodaModel { Name = "Pepsi", SlotOccupied = "A1" };
            (SodaModel soda, List<CoinModel> coins, string message) result;

            sodaMachineLogic.MoneyInserted(userId, amount);
            sodaMachineLogic.MoneyInserted(userId, amount);
            result = sodaMachineLogic.RequestSoda(requestedSoda);
            actualSoda = result.soda;
            coinCount = result.coins.Count;

            System.Console.WriteLine(result.coins.Count.ToString() + coinCount);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(requestedSoda.Name, actualSoda.Name);
                Assert.AreEqual(requestedSoda.SlotOccupied, actualSoda.SlotOccupied);
                Assert.That(coinCount, Is.GreaterThan(0));
            });
        }

        [Test]
        public void RequestSoda_ShouldReturnNoChange()
        {
            int expectedCoinCount = 0;
            int actualCount;
            SodaModel soda = new SodaModel { Name = "Pepsi", SlotOccupied = "A1" };

            (SodaModel soda, List<CoinModel> coins, string message) result = sodaMachineLogic.RequestSoda(soda);
            actualCount = result.coins.Count;

            Assert.AreEqual(expectedCoinCount, actualCount);
        }

        [Test]
        public void RequestSoda_ShouldSayNotEnoughMoney()
        {
            string expectedMessage = "Not enough money";
            SodaModel soda = new SodaModel { Name = "Pepsi", SlotOccupied = "A1" };

            (SodaModel soda, List<CoinModel> coins, string message) result = sodaMachineLogic.RequestSoda(soda);

            Assert.AreEqual(expectedMessage, result.message);
        }

        [Test]
        public void RequestSoda_ShouldSayOutOfStock()
        {
            string expectedMessage = "Out of stock";
            SodaModel soda = new SodaModel { Name = "Pepsi", SlotOccupied = "C1" };

            (SodaModel soda, List<CoinModel> coins, string message) result = sodaMachineLogic.RequestSoda(soda);

            Assert.AreEqual(expectedMessage, result.message);
        }
    }
}
