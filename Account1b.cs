using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account1b;
class Account
{
    int balance;
    public void insertInto(int amount)
    {
        balance += amount;
    }
    public void writeBalance()
    {
        Console.WriteLine($"Na účtu je: {balance}");
    }
    public void transferTo(Account u, int c)
    {
        u.balance += c;
        balance -= c;
    }
    public void transferTo(Account u)
    {
        //u.balance += this.balance;
        ////balance = 0;
        //this.balance -= this.balance;
        transferTo(u, this.balance);
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
        u1.transferTo(u2);
        u1.writeBalance(); u2.writeBalance();
    }
}
