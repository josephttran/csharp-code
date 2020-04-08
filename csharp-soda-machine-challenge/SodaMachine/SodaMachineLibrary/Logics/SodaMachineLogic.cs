using System;
using SodaMachineLibrary.Models;
using System.Collections.Generic;
using SodaMachineLibrary.DataAccess;

namespace SodaMachineLibrary.Logics
{
    public class SodaMachineLogic : ISodaMachineLogic
    {
        private readonly IDataAccess _dataAccess;

        public SodaMachineLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void AddToCoinInventory(List<CoinModel> coins) 
        {
            throw new Exception("Not implemented");
        }

        public void AddToSodaInventory(List<SodaModel> sodas)
        {
            throw new Exception("Not implemented");
        }

        public decimal EmptyMoneyFromMachine()
        {
            throw new Exception("Not implemented");
        }

        public List<CoinModel> GetCoinInventory()
        {
            throw new Exception("Not implemented");
        }

        public decimal GetCurrentIncome()
        {
            throw new Exception("Not implemented");
        }

        public decimal GetMoneyInsertedTotal(string userId)
        {
            throw new Exception("Not implemented");
        }

        public List<SodaModel> GetSodaInventory()
        {
            throw new Exception("Not implemented");
        }

        public decimal GetSodaPrice()
        {
            throw new Exception("Not implemented");
        }

        public decimal GetTotalIncome()
        {
            throw new Exception("Not implemented");
        }

        public decimal IssueFullRefund()
        {
            throw new Exception("Not implemented");
        }

        public List<SodaModel> ListTypesOfSoda()
        {
            throw new Exception("Not implemented");
        }

        public decimal MoneyInserted(string userId, decimal amount)
        {
            throw new Exception("Not implemented");
        }

        public (SodaModel soda, List<CoinModel> coins, string message) RequestSoda(SodaModel soda)
        {
            throw new Exception("Not implemented");
        }
    }
}
