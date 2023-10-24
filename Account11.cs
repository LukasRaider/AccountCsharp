using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account11;
class Account
{
    int balance;
    public void insertInto(int c)
    {
        if ((balance + c) < 0) throw new ArgumentOutOfRangeException(
                         "Na účtu není pro VÝBĚR dostatek peněz,je zde " + balance + "Kč");
        balance += c;
    }
    public void writeBalance()
    {
        Console.Write("Na účtu je: " + balance);
    }
    public void transferTo(Account u, int c)
    {
        if ((balance - c) < 0)
            throw new ArgumentOutOfRangeException(
                    "Na účtu není pro PŘEVOD dostatek peněz,je zde " + balance + "Kč");
        if (c < 0)
            throw new ArgumentOutOfRangeException("Nesmíš vysávat cizí účty");
        if (c == 0)
            throw new ArgumentOutOfRangeException("Nelze převádět 0 Kč.");
        if (this == u)
            throw new ArgumentOutOfRangeException("Nelze převádět sám sobě.");

        u.balance += c;
        balance -= c;
    }
    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account(); Account u2 = new Account();
        do
        {                                                                     //
            Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej vklad (výběr je záporný) (celé číslo)");
            amount = int.Parse(Console.ReadLine());
            try
            {
                u1.insertInto(amount);
                break;                                                               //
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            } //
        } while (true);                                                          //

        bool ok;                                                                 //                                  
        if (u1.balance > 0)
        {
            do
            {                                                                     //
                ok = true;                                                           //        
                Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
                amount = int.Parse(Console.ReadLine());
                try
                {
                    u1.transferTo(u2, amount);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message); //
                    ok = false;
                }//
            } while (!ok);                                                   //

            Console.WriteLine("Zůstatek je " + u1.balance);

        }
    }
}
