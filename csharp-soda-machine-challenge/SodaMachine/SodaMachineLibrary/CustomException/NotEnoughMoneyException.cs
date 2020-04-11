using System;

namespace SodaMachineLibrary.CustomException
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base("Not enough money")
        {
        }
    }
}
