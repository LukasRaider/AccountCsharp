using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account7;
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
    public void transferTo(Account ucet, int castka)
    {
        ucet.balance += castka;
        balance -= castka;
    }
    public static void Mainx(String[] args)
    {
        int amount;                                                     //
        Account u1 = new Account();
        Console.WriteLine("Zadej částku pro vložení/výběr peněz (celé číslo)"); //
                                                                                // amount = int.Parse(Console.ReadLine());
                                                                                //amount = Convert.ToInt32(Console.ReadLine());//
        amount = Int32.Parse(Console.ReadLine());
        u1.insertInto(amount);
        Console.WriteLine($"Zůstatek je {u1.balance}");
    }
}
