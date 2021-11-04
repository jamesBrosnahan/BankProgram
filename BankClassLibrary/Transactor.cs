using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLibrary
{
    public static class Transactor
    {
        public static bool Deposit(Account account, float amount)
        {
            account.balance += amount;
            return true;
        }

        public static bool Withdrawal(Account account, float amount)
        {
            if(account.GetType().Equals(typeof(IndividualInvestmentAccount)) && amount > 500)
            {
                return false;
            }
            account.balance -= amount;
            return true;
        }

        public static bool Transfer(Account SenderAccount, Account ReceiverAccount, float amount)
        {
            bool withdrawal = Transactor.Withdrawal(SenderAccount, amount);
            if(withdrawal == false)
            {
                return false;
            }
            Transactor.Deposit(ReceiverAccount, amount);
            return true;
        }
    }
}
