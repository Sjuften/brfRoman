﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomeNumberConverter.App;
using RomeNumberConverter.App.Types;
using static RomeNumberConverter.App.Enums.ConverterTypes;

namespace RomeNumberConverter.Test
{
    [TestClass]
    public class ConverterFactoryTest
    {
        [TestMethod]
        public void ConvertFactoryReturnRomanDecimal()
        {
            var romanDecimal = ConverterFactory.Get(string.Empty, Converters.RomanDecimal);
            Assert.IsInstanceOfType(romanDecimal, typeof(RomanDecimalConveter));
        }
    }
}
