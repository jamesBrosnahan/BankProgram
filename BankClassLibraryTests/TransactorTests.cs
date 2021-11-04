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
            account.balance = startingBalance;
            bool result = Transactor.Deposit(account, depositAmount);
            Assert.IsTrue(result);
            Assert.AreEqual(account.balance, expectedBalance);
        }
        [TestMethod]
        public void TestWithdrawal()
        {
            float withdrawalAmount = 100_000;
            float startingBalance = 200_000;
            float expectedBalance = 100_000;

            Account account = new Account();
            account.balance = startingBalance;

            bool result = Transactor.Withdrawal(account, withdrawalAmount);
            Assert.AreEqual(account.balance, expectedBalance);
        }

        [TestMethod]
        public void Test500DollarWithdrawalLimitOnIndividualInvestmentAccounts()
        {
            float withdrawalAmount = 100_000;
            float startingBalance = 200_000;
            float expectedBalance = 200_000;

            IndividualInvestmentAccount account = new IndividualInvestmentAccount();
            account.balance = startingBalance;

            bool result = Transactor.Withdrawal(account, withdrawalAmount);
            Assert.IsFalse(result);
            Assert.AreEqual(account.balance, expectedBalance);
        }
        [TestMethod]
        public void TestTransfer()
        {
            Account senderAccount = new Account();
            Account receiverAccount = new Account();
            float senderStartingBalance = 100_000;
            float receiverStartingBalance = 100_000;
            senderAccount.balance = senderStartingBalance;
            receiverAccount.balance = receiverStartingBalance;
            float transferAmount = 50_000;
            float expectedSenderBalance = 50_000;
            float expectedReceiverBalance = 150_000;
            bool result = Transactor.Transfer(senderAccount, receiverAccount, transferAmount);
            Assert.IsTrue(result);
            Assert.AreEqual(senderAccount.balance, expectedSenderBalance);
            Assert.AreEqual(receiverAccount.balance, expectedReceiverBalance);
        }

        [TestMethod]
        public void Test500DollarWithdrawalLimitOnIndividualInvestmentTransfer()
        {
            IndividualInvestmentAccount senderAccount = new IndividualInvestmentAccount();
            Account receiverAccount = new Account();
            float senderStartingBalance = 100_000;
            float receiverStartingBalance = 100_000;
            senderAccount.balance = senderStartingBalance;
            receiverAccount.balance = receiverStartingBalance;
            float transferAmount = 50_000;
            float expectedSenderBalance = 100_000;
            float expectedReceiverBalance = 100_000;
            bool result = Transactor.Transfer(senderAccount, receiverAccount, transferAmount);
            Assert.IsFalse(result);
            Assert.AreEqual(senderAccount.balance, expectedSenderBalance);
            Assert.AreEqual(receiverAccount.balance, expectedReceiverBalance);
        }

    }
}
