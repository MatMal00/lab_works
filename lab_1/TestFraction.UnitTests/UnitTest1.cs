using FirstApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestFraction.UnitTests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void NumbericRepresentation_NumberToOnePlace_ReturnsNumberToOnePlace()
        {
            var fraction = new Fraction(1, 2);

            var result = fraction.NumbericRepresentation(1);

            Assert.AreEqual(result, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "wrong argument")]
        public void NumbericRepresentation_NumberMinusPlace_Throws_Exception()
        {
            var fraction = new Fraction(1, 2);

            fraction.NumbericRepresentation(-1);
        }

        [TestMethod]
        public void RoundFraction_RoundUp_ShouldRoundUp()
        {
            var fraction = new Fraction(1, 2);

            var result = fraction.RoundFraction(0);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void RoundFraction_RoundDown_ShouldRoundDown()
        {
            var fraction = new Fraction(1, 2);

            var result = fraction.RoundFraction(1);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CompareTo_CompareSameFractions_ShouldReturnZero()
        {
            var fraction = new Fraction(1, 2);
            var fraction2 = new Fraction(1, 2);

            var result = fraction.CompareTo(fraction2);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CompareTo_CompareDifferentFractions_ShouldReturnOne()
        {
            var fraction = new Fraction(1, 2);
            var fraction2 = new Fraction(1, 3);

            var result = fraction.CompareTo(fraction2);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void Equals_SameRecord_ShouldReturnTrue()
        {
            var fraction = new Fraction(1, 2);
            var fraction2 = new Fraction(1, 2);

            var result = fraction.Equals(fraction2);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Equals_DifferentRecord_ShouldReturnFalse()
        {
            var fraction = new Fraction(1, 2);
            var fraction2 = new Fraction(2, 4);

            var result = fraction.Equals(fraction2);

            Assert.AreEqual(result, false);
        }

    }
}