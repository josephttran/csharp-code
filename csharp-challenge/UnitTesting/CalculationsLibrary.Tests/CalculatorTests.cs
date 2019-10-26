using System;
using NUnit.Framework;

namespace CalculationsLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_OneAndTwo_ShouldReturnThree()
        {
            // Arrange
            double expected = 3;

            // Act
            double actual = Calculator.Add(1, 2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Divide_DivideByZero_ShouldThrowException()
        {
            TestDelegate testDelegate = () => Calculator.Divide(4, 0);
            string expectedMessage = "Cannot divide by zero";

            Assert.Throws(
                Is.TypeOf<ArgumentException>().And.Message.EqualTo(expectedMessage), 
                testDelegate);
        }

        [Test]
        public void Divide_TwentyDivideByFour_ShouldReturnFive()
        {
            // Arrange
            double expected = 5;

            // Act
            double actual = Calculator.Divide(20, 4);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, 0, 50)]
        [TestCase(0, 50, 0, 50)]
        [TestCase(50, 0, 0, 50)]
        [TestCase(50, 50, 0, 50)]
        public void LimitedAdd_ShouldCalculate(double x, double y, double minValue, double maxValue)
        {
            double expected = x + y;
            double number = Calculator.LimitedAdd(x, y, minValue, maxValue);

            Assert.AreEqual(expected, number);
        }

        [TestCase(-1, 25, 0, 50)]
        [TestCase(51, 25, 0, 50)]
        public void LimitedAdd_ShouldThrowXOutOfRange(double x, double y, double minValue, double maxValue)
        {
            TestDelegate testDelegate = () => Calculator.LimitedAdd(x, y, minValue, maxValue);
            string expectedMessage = "x is outside the specified bounds (Parameter 'x')";

            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>().And.Message.EqualTo(expectedMessage), 
                testDelegate);
        }

        [TestCase(15, -1, 0, 50)]
        [TestCase(15, 51, 0, 50)]
        public void LimitedAdd_ShouldThrowYOutofRange(double x, double y, double minValue, double maxValue)
        {
            TestDelegate testDelegate = () => Calculator.LimitedAdd(x, y, minValue, maxValue);
            string expectedMessage = "y is outside the specified bounds (Parameter 'y')";

            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>().And.Message.EqualTo(expectedMessage), 
                testDelegate);
        }
    }
}