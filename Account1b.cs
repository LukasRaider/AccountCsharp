using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account1b
{
    class Account
    {
        public int balance;
        public void insertInto(int amount)
        {
            balance += amount;
        }
        public void writeBalance()
        {
            Console.WriteLine($"Na účtu je: {balance}");
        }
        public void transferTo(Account ucet, int castka)
        {
            ucet.balance += castka;
            this.balance -= castka;
        }
        public void transferTo(Account ucet, Account ucet2, int castka )
        {
            ucet.balance += castka;
            ucet2.balance -= castka;
        }

    }
    class TestAccount
    {
        public static void Mainx(string[] args)
        {
            Account u1 = new Account();
            Account u2 = new Account();
            u1.insertInto(100); u2.insertInto(100);
            u1.transferTo(u2, 50);
            u1.writeBalance(); u2.writeBalance();
            u1.insertInto(-10);
            u1.transferTo(u2, 10);
            Console.Write($"{nameof(u1)}:");
            u1.writeBalance();
            Console.Write($"{nameof(u2)}:");
            u2.writeBalance();
            u1.transferTo(u1, u2, 200);
            Console.Write($"{nameof(u1)}:");
            u1.writeBalance();
            Console.Write($"{nameof(u2)}:");
            u2.writeBalance();
        }
    }
}
