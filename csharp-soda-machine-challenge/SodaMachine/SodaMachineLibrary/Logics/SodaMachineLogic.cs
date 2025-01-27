﻿using System;
using SodaMachineLibrary.CustomException;
using SodaMachineLibrary.Models;
using System.Collections.Generic;
using SodaMachineLibrary.DataAccess;
using System.Linq;

namespace SodaMachineLibrary.Logics
{
    public class SodaMachineLogic : ISodaMachineLogic
    {
        private readonly IDataAccess _dataAccess;
        private string _userId;
        public List<decimal> AcceptedCoinValues { get; set; }

        public SodaMachineLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _userId = "user1234";

            AcceptedCoinValues = new List<decimal>()
            {
                0.25M,
                1.00M
            };
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
            List<CoinModel> coins = new List<CoinModel>();
            decimal totalRefund = _dataAccess.UserCreditTotal(userId);

            _dataAccess.UserCreditInsert(userId, -totalRefund);

            if (totalRefund != 0)
            {
                int dollarQuantity = 0;
                int quarterQuantity = 0;

                while (totalRefund >= 1.00M)
                {
                    dollarQuantity++;
                    totalRefund = decimal.Subtract(totalRefund, 1.00M);
                }

                while (totalRefund >= 0.25M)
                {
                    quarterQuantity++;
                    totalRefund = decimal.Subtract(totalRefund, 0.25M);
                }

                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(1.00M, dollarQuantity));
                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(0.25M, quarterQuantity));

                _dataAccess.UserCreditClear(userId);
            }

            if (coins.Count > 0)
            {
                return coins.Sum(coinModel => coinModel.Amount);
            }

            return 0;
        }

        public List<SodaModel> ListTypesOfSoda()
        {
            return _dataAccess.SodaInventoryGetTypes();
        }

        public decimal MoneyInserted(string userId, decimal amount)
        {
            _userId = userId;

            if (!AcceptedCoinValues.Contains(amount))
            {
                Console.WriteLine("Invalid currency!");
                _dataAccess.UserCreditInsert(userId, 0);
                return _dataAccess.UserCreditTotal(userId);
            }

            List<CoinModel> coins = new List<CoinModel>();

            if (amount == 1.00M)
            {
                coins.Add(new CoinModel() { Name = "Dollar", Amount = 1.00M });           
            }

            if (amount == 0.25M)
            {
                coins.Add(new CoinModel() { Name = "Quarter", Amount = 0.25M });
            }

            _dataAccess.CoinInventoryAddCoins(coins);
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

                _dataAccess.UserCreditInsert(_userId, -change);

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
                }

                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(1.00M, dollarQuantity));
                coins.AddRange(_dataAccess.CoinInventoryWithdrawCoins(0.25M, quarterQuantity));

                _dataAccess.UserCreditClear(_userId);

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
