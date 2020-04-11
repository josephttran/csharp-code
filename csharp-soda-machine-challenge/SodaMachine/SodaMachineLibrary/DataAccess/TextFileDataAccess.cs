using Microsoft.Extensions.Configuration;
using SodaMachineLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SodaMachineLibrary.DataAccess
{
    public class TextFileDataAccess : IDataAccess
    {
        private readonly string _coinInventoryPath;
        private readonly string _sodaInventoryPath;
        private readonly string _machineInfoPath;
        private readonly string _userCreditPath;

        public TextFileDataAccess(IConfiguration configuration)
        {
            _coinInventoryPath = configuration.GetSection("TextFileDataAccessPath:CoinInventoryPath").Value;
            _machineInfoPath = configuration.GetSection("TextFileDataAccessPath:MachineInfoPath").Value;
            _sodaInventoryPath = configuration.GetSection("TextFileDataAccessPath:SodaInventoryPath").Value;
            _userCreditPath = configuration.GetSection("TextFileDataAccessPath:UserCreditPath").Value;
        }

        public void CoinInventoryAddCoins(List<CoinModel> coins)
        {
            List<CoinModel> coinInventory = new List<CoinModel>();
            List<string> output = new List<string>();

            coinInventory = CoinInventoryGetAll();
            coinInventory.AddRange(coins);

            foreach(var coinModel in coinInventory)
            {
                output.Add($"{ coinModel.Name },{ coinModel.Amount }");
            }

            File.WriteAllLines(_coinInventoryPath, output);
        }

        public List<CoinModel> CoinInventoryGetAll()
        {
            List<CoinModel> coinInventory = new List<CoinModel>();
            List<string> coinLines = File.ReadAllLines(_coinInventoryPath).ToList();

            foreach (var line in coinLines)
            {
                try
                {
                    string[] entries = line.Split(',');
                    string coinName = entries[0];
                    decimal coinValue = decimal.Parse(entries[1]);
                    coinInventory.Add(new CoinModel { Name = coinName, Amount = coinValue });
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse coin value!");
                }
            }

            return coinInventory;
        }

        public List<CoinModel> CoinInventoryWithdrawCoins(decimal coinValue, int quantity)
        {
            List<CoinModel> coinInventory = new List<CoinModel>();
            List<string> output = new List<string>();
            List<CoinModel> coins = new List<CoinModel>();

            coinInventory = CoinInventoryGetAll();

            for (int num = 0; num < quantity; num++)
            {
                coins.Add(coinInventory.Find(x => x.Amount == coinValue));
                coinInventory.Remove(coins[num]);
            }

            foreach (var coinModel in coinInventory)
            {
                output.Add($"{ coinModel.Name },{ coinModel.Amount }");
            }

            File.WriteAllLines(_coinInventoryPath, output);

            return coins;
        }

        public decimal MachineInfoCashOnHand()
        {
            try
            {
                string[] machineInfoEntry = File.ReadLines(_machineInfoPath).First().Split(',');
                decimal cashOnHand = decimal.Parse(machineInfoEntry[0]);

                return cashOnHand;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse machine info cash on hand!");
            }

            throw new Exception("Error machine info cash on hand");
        }

        public decimal MachineInfoEmptyCash()
        {
            try
            {
                string[] machineInfoEntry = File.ReadLines(_machineInfoPath).First().Split(',');
                decimal cashOnHand = decimal.Parse(machineInfoEntry[0]);
                decimal sodaPrice = decimal.Parse(machineInfoEntry[1]);
                decimal totalIncome = decimal.Parse(machineInfoEntry[2]);

                string coinInventoryUpdated = "";
                string machineInfoUpdated = $"0,{ sodaPrice },{ totalIncome }";

                File.WriteAllText(_coinInventoryPath, coinInventoryUpdated);
                File.WriteAllText(_machineInfoPath, machineInfoUpdated);

                return cashOnHand;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse machine info!");
            }

            throw new Exception("Error machine info empty cash");
        }

        public decimal MachineInfoSodaPrice()
        {
            try
            {
                string[] machineInfoEntry = File.ReadLines(_machineInfoPath).First().Split(',');
                decimal sodaPrice = decimal.Parse(machineInfoEntry[1]);
                return sodaPrice;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse machine info soda price!");
            }

            throw new Exception("Error soda price");
        }

        public decimal MachineInfoTotalIncome()
        {
            try
            {
                string[] machineInfoEntry = File.ReadLines(_machineInfoPath).First().Split(',');
                decimal totalIncome = decimal.Parse(machineInfoEntry[2]);
                return totalIncome;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse machine info!");
            }

            throw new Exception("Error total income");
        }

        public void SodaInventoryAddSodas(List<SodaModel> sodas)
        {
            List<SodaModel> sodaInventory = new List<SodaModel>();
            List<string> output = new List<string>();

            sodaInventory = SodaInventoryGetAll();
            sodaInventory.AddRange(sodas);

            foreach (var sodaModel in sodaInventory)
            {
                output.Add($"{ sodaModel.Name },{ sodaModel.SlotOccupied }");
            }

            File.WriteAllLines(_sodaInventoryPath, output);


            sodaInventory.AddRange(sodas);
        }

        public List<SodaModel> SodaInventoryGetAll()
        {
            List<SodaModel> sodaInventory = new List<SodaModel>();
            List<string> sodaLines = File.ReadAllLines(_sodaInventoryPath).ToList();

            foreach (var line in sodaLines)
            {
                string[] entries = line.Split(',');
                string sodaName = entries[0];
                string slotOccupied = entries[1];
                sodaInventory.Add(new SodaModel { Name = sodaName, SlotOccupied = slotOccupied });
            }

            return sodaInventory;
        }

        public SodaModel SodaInventoryGetSoda(SodaModel soda)
        {
            List<SodaModel> sodaInventory = new List<SodaModel>();

            sodaInventory = SodaInventoryGetAll();

            return sodaInventory.Find(sodaInventorySoda =>
                sodaInventorySoda.Name == soda.Name &&
                sodaInventorySoda.SlotOccupied == soda.SlotOccupied
            );
        }

        public List<SodaModel> SodaInventoryGetTypes()
        {
            List<SodaModel> sodaInventory = new List<SodaModel>();

            sodaInventory = SodaInventoryGetAll();

            return sodaInventory.GroupBy(x => x.Name).Select(g => g.First()).ToList();
        }

        public void UserCreditClear(string userId)
        {
            Dictionary<string, decimal> userCredit = new Dictionary<string, decimal>();
            List<string> output = new List<string>();

            userCredit = UserCreditGetAll();
            userCredit[userId] = 0;

            foreach (var keyValuePair in userCredit)
            {
                output.Add($"{ keyValuePair.Key },{ keyValuePair.Value }");
            }

            File.WriteAllLines(_userCreditPath, output);
        }

        public void UserCreditDeposit(string userId)
        {
            Dictionary<string, decimal> userCredit = new Dictionary<string, decimal>();
            List<string> output = new List<string>();

            userCredit = UserCreditGetAll();
            userCredit.Add(userId, 0);

            foreach (var keyValuePair in userCredit)
            {
                output.Add($"{ keyValuePair.Key },{ keyValuePair.Value }");
            }

            File.WriteAllLines(_userCreditPath, output);
        }

        public void UserCreditInsert(string userId, decimal amount)
        {
            Dictionary<string, decimal> userCredit = new Dictionary<string, decimal>();
            List<string> output = new List<string>();

            userCredit = UserCreditGetAll();

            if (userCredit.ContainsKey(userId))
            {
                userCredit[userId] += amount;
            }
            else
            {
                userCredit[userId] = 0;
            }

            foreach (var keyValuePair in userCredit)
            {
                output.Add($"{ keyValuePair.Key },{ keyValuePair.Value }");
            }

            File.WriteAllLines(_userCreditPath, output);


        }

        public decimal UserCreditTotal(string userId)
        {
            Dictionary<string, decimal> userCredit = new Dictionary<string, decimal>();
            List<string> output = new List<string>();

            userCredit = UserCreditGetAll();

            return userCredit[userId];
        }

        private Dictionary<string, decimal> UserCreditGetAll()
        {
            List<string> userCreditLines = File.ReadAllLines(_userCreditPath).ToList();
            Dictionary<string, decimal> userCredit = new Dictionary<string, decimal>();

            foreach (var line in userCreditLines)
            {
                try
                {
                    string[] userCreditEntry = line.Split(',');
                    string userId = userCreditEntry[0];
                    decimal credit = decimal.Parse(userCreditEntry[1]);
                    userCredit.Add(userId, credit);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse user credit!");
                }
            }

            return userCredit;
        }
    }
}
