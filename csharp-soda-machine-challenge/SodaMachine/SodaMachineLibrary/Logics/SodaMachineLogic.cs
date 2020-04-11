using System;
using SodaMachineLibrary.CustomException;
using SodaMachineLibrary.Models;
using System.Collections.Generic;
using SodaMachineLibrary.DataAccess;

namespace SodaMachineLibrary.Logics
{
    public class SodaMachineLogic : ISodaMachineLogic
    {
        private readonly IDataAccess _dataAccess;
        private string _userId;

        public SodaMachineLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _userId = "user1234";

        }

        public void AddToCoinInventory(List<CoinModel> coins)
        {
            if (coins.Count > 0)
            {
                _dataAccess.CoinInventoryAddCoins(coins);
            }
        }

        public void AddToSodaInventory(List<SodaModel> sodas)
        {
            if (sodas.Count > 0)
            {
                _dataAccess.SodaInventoryAddSodas(sodas);
            }
        }

        public decimal EmptyMoneyFromMachine()
        {
            return _dataAccess.MachineInfoEmptyCash();
        }

        public List<CoinModel> GetCoinInventory()
        {
            return _dataAccess.CoinInventoryGetAll();
        }

        public decimal GetCurrentIncome()
        {
            return _dataAccess.MachineInfoCashOnHand();
        }

        public decimal GetMoneyInsertedTotal(string userId)
        {
            return _dataAccess.UserCreditTotal(userId);
        }

        public List<SodaModel> GetSodaInventory()
        {
            return _dataAccess.SodaInventoryGetAll();
        }

        public decimal GetSodaPrice()
        {
            return _dataAccess.MachineInfoSodaPrice();
        }

        public decimal GetTotalIncome()
        {
            return _dataAccess.MachineInfoTotalIncome();
        }

        public decimal IssueFullRefund(string userId)
        {
            decimal totalRefund = _dataAccess.UserCreditTotal(userId);

            return totalRefund;
        }

        public List<SodaModel> ListTypesOfSoda()
        {
            return _dataAccess.SodaInventoryGetTypes();
        }

        public decimal MoneyInserted(string userId, decimal amount)
        {
            _userId = userId;
            _dataAccess.UserCreditInsert(userId, amount);
            return _dataAccess.UserCreditTotal(userId);
        }

        public (SodaModel soda, List<CoinModel> coins, string message) RequestSoda(SodaModel soda)
        {
            try
            {
                SodaModel machineSoda = _dataAccess.SodaInventoryGetSoda(soda);
                decimal userCredit = _dataAccess.UserCreditTotal(_userId);
                decimal sodaPrice = _dataAccess.MachineInfoSodaPrice();

                if (machineSoda == null)
                {
                    throw new OutOfStockException();
                }

                if (userCredit < sodaPrice)
                {
                    throw new NotEnoughMoneyException();
                }

                List<CoinModel> coins = new List<CoinModel>();
                decimal change = userCredit - sodaPrice;

                int dollarQuantity = 0;
                int quarterQuantity = 0;

                while (change >= 1.00M)
                {
                    dollarQuantity++;
                    change = decimal.Subtract(change, 1.00M);
                }

                while (change >= 0.25M)
                {
                    quarterQuantity++;
                    change = decimal.Subtract(change, 0.25M);
                    Console.WriteLine("ghjk" + machineSoda.Name);

                }

                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(1.00M, dollarQuantity));
                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(0.25M, quarterQuantity));

                return (machineSoda, coins, "Enjoy the refreshment");
            }
            catch (OutOfStockException ex)
            {
                return (new SodaModel(), new List<CoinModel>(), ex.Message);
            }
            catch (NotEnoughMoneyException ex)
            {
                return (new SodaModel(), new List<CoinModel>(), ex.Message);
            }

            throw new Exception("Request soda failed");
        }
    }
}
