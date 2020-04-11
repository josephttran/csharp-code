using System;

namespace SodaMachineLibrary.CustomException
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException() : base("Out of stock")
        {
        }
    }
}
