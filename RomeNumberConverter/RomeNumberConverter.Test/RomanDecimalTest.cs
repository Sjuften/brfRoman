using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomeNumberConverter.App;
using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.Test
{
    [TestClass]
    public class RomanDecimalTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void TestInputFailException()
        {
            var decimalRoman = new RomanDecimalConveter("input");
        }

        [TestMethod]
        public void TestRomanDecimalConstructorWithRomanInputSucces()
        {
            var decimalRoman = new RomanDecimalConveter("x");
            Assert.IsInstanceOfType(decimalRoman, typeof(RomanDecimalConveter));
        }

        [TestMethod]
        public void TestRomanDecimalConstructorWithDecimalInputSucces()
        {
            var decimalRoman = new RomanDecimalConveter("20");
            Assert.IsInstanceOfType(decimalRoman, typeof(RomanDecimalConveter));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void VLDRepetitionFailWithV()
        {
            var decimalRoman = new RomanDecimalConveter("VVV").GetResult();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void VLDRepetitionFailWithL()
        {
            var decimalRoman = new RomanDecimalConveter("LL").GetResult();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void VLDRepetitionFailWithD()
        {
            var decimalRoman = new RomanDecimalConveter("DD").GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void ValidateLetterRepititionFail()
        {
            var decimalRoman = new RomanDecimalConveter("IIII").GetResult();
        }
        [TestMethod]
        public void ValidateTheValueOfThreeLetterReptitionWithSucces()
        {
            var expected = 3;
            var decimalRoman = int.Parse(new RomanDecimalConveter("III").GetResult());
            Assert.AreEqual(expected, decimalRoman);
        }
        [TestMethod]
        public void ValidateTheValueOfThirteenLetterReptitionWithSucces()
        {
            var expected = 13;
            var decimalRoman = int.Parse(new RomanDecimalConveter("XIII").GetResult());
            Assert.AreEqual(expected, decimalRoman);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void ValidateSubtractiveCombinationWithDivisionWithFailWithValueIC()
        {
            var decimalRoman = new RomanDecimalConveter("IC").GetResult();
        }
        [TestMethod]
        public void ValidateSubtractiveCombinationWithDivisionWithSuccesValueXCIX()
        {
            var expected = 99;
            var decimalRoman = int.Parse(new RomanDecimalConveter("XCIX").GetResult());
            Assert.AreEqual(expected, decimalRoman);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void ValidateTheComparedSizeFromLeftToRightFailWithValueXIM()
        {
            var decimalRoman = new RomanDecimalConveter("XIM").GetResult();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void ValidateTheComparedSizeFromLeftToRightFailWithValueIIVM()
        {
            var decimalRoman = new RomanDecimalConveter("IIV").GetResult();
        }
        [TestMethod]
        public void ValidateTheComparedSizeFromLeftToRightSuccesWithValueXIX()
        {
            var expected = 19;
            var decimalRoman = int.Parse(new RomanDecimalConveter("XIX").GetResult());
            Assert.AreEqual(expected, decimalRoman);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input is not valid")]
        public void CheckDecimalInputNotValidError()
        {
            var decimalRoman = new RomanDecimalConveter("50000").GetResult();
        }
        [TestMethod]
        public void GetResultOfXToDecimal()
        {
            var expected = "X";
            var decimalRoman = new RomanDecimalConveter("10").GetResult();
            Assert.AreEqual(expected, decimalRoman);
        }

    }
}
