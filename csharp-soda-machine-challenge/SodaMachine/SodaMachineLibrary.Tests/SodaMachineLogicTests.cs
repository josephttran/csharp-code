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

        [SetUp]
        public void Setup()
        {
            MockDataAccess mockDataAccess = new MockDataAccess();
            sodaMachineLogic = new SodaMachineLogic(mockDataAccess);
        }

        [Test]
        public void AddToCoinInventory_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void AddToSodaInventory_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void EmptyMoneyFromMachine_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetCoinInventory_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetCurrentIncome_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetMoneyInsertedTotal_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetSodaInventory_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetSodaPrice_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void GetTotalIncome_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void IssueFullRefund_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void ListTypesOfSoda_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void MoneyInserted_SingleUserShouldHaveCorrectAmount()
        {
            Assert.Fail();
        }

        [Test]
        public void RequestSoda_ShouldReturnSodaWithAlternateChange()
        {
            Assert.Fail();
        }

        [Test]
        public void RequestSoda_ShouldReturnSodaWithChange()
        {
            Assert.Fail();
        }

        [Test]
        public void RequestSoda_ShouldReturnNoChange()
        {
            Assert.Fail();
        }

        [Test]
        public void RequestSoda_ShouldSayNotEnoughMoney()
        {
            Assert.Fail();
        }

        [Test]
        public void RequestSoda_ShouldSayOutOfStock()
        {
            Assert.Fail();
        }
    }
}
