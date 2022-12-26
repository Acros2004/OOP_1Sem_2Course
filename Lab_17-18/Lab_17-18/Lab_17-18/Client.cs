using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18
{
    internal class Client
    {
        public string name;
        
        public Client(string name)
        {
            this.name = name;
        }

        public void depositMoneyInTheBankAccounts(BankAccount bankAccount, double money)
        {
            bankAccount.AddMoney(money);
        }

        public void makePayment(BankAccount bankAccount, double money)
        {
            bankAccount.RemoveMoney(money);
        }
        public void BlockedBankAccount(BankAccount bankAccount)
        {
            bankAccount.Blocked();
        }
    }
}
