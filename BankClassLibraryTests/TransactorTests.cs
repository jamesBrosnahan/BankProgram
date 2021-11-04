using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankClassLibrary;

namespace BankClassLibraryTests
{
    [TestClass]
    public class TransactorTests
    {
        [TestMethod]
        public void TestDeposit()
        {
            float depositAmount = 100_000;
            float startingBalance = 200_000;
            float expectedBalance = 300_000;

            Account account = new Account();

        }
        [TestMethod]
        public void TestWithdrawal()
        {
        }

        [TestMethod]
        public void Test500DollarWithdrawalLimitOnIndividualInvestmentAccounts()
        {

        }
        [TestMethod]
        public void TestTransfer()
        {
        }

    }
}
