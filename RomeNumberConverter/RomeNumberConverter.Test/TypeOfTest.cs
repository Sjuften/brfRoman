using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomeNumberConverter.App;

namespace RomeNumberConverter.Test
{
    [TestClass]
    public class TypeOfTest
    {
        [TestMethod]
        public void TypeOfDecimalTrue()
        {
            var expected = true;
            var isDecimal = TypeOf.IsDecimal("20");
            Assert.AreEqual(expected, isDecimal);
        }

        [TestMethod]
        public void TypeOfDecimalFalse()
        {
            var expected = false;
            var isDecimal = TypeOf.IsDecimal("IsNotDecimal");
            Assert.AreEqual(expected, isDecimal);
        }
        [TestMethod]
        public void TypeOfRomanTrue()
        {
            var expected = true;
            var isDecimal = TypeOf.IsRoman("X");
            Assert.AreEqual(expected, isDecimal);
        }

        [TestMethod]
        public void TypeOfRomanFalse()
        {
            var expected = false;
            var isDecimal = TypeOf.IsDecimal("IsNotRoman");
            Assert.AreEqual(expected, isDecimal);
        }
    }
}
