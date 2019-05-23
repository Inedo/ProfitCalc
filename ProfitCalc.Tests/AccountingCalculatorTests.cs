﻿using System;
using ProfitCalc.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfitCalc.Tests
{
    [TestClass]
    public class AccountingCalculatorTests
    {
        [TestMethod]
        public void CalculateProfit()
        {
            IAccountingCalculator calc = new AccountingCalculator();
            decimal net = calc.CalculateNet(1000m, 1000m);

            Assert.AreEqual(0m, net);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeRevenue()
        {
            IAccountingCalculator calc = new AccountingCalculator();
            decimal net = calc.CalculateNet(-1000m, 1000m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeExpenses()
        {
            IAccountingCalculator calc = new AccountingCalculator();
            decimal net = calc.CalculateNet(1000m, -1000m);
        }
    }
}
