using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account10;
class Account
{
    int balance;
    public void insertInto(int castka)
    {    //zmizel try a catch
        if ((balance + castka) < 0) throw new ArgumentOutOfRangeException(
                 "Na účtu není pro VÝBĚR dostatek peněz,je zde " + balance + "Kč");
        balance += castka;
    }
    public void writeBalance()
    {
        Console.Write("Na účtu je: " + balance);
    }
    public void transferTo(Account ucet, int castka)
    {    //zmizel try a catch       //   
        if ((balance - castka) < 0)
            throw new ArgumentOutOfRangeException(
                "Na účtu není pro PŘEVOD dostatek peněz,je zde " + balance + "Kč");
        if (castka < 0)
            throw new ArgumentOutOfRangeException("Nesmíš vysávat cizí účty");
        if (castka == 0)
            throw new ArgumentOutOfRangeException("Nelze převádět 0 Kč.");
        if (this == ucet)
            throw new ArgumentOutOfRangeException("Nelze převádět sám sobě.");

        ucet.balance += castka;
        balance -= castka;
    }

    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account(); Account u2 = new Account();
        Console.Write("Na účtu je " + u1.balance + " Kč. Zadej vklad (výběr je záporný) (celé číslo)");
        amount = int.Parse(Console.ReadLine());
        try
        {                                                                   //
            u1.insertInto(amount);
        }                                                                       //
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        } //   

        Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
        amount = int.Parse(Console.ReadLine());
        try
        {                                                                   //
            u1.transferTo(u2, amount);
        }                                                                       //
        catch (ArgumentOutOfRangeException e) { Console.WriteLine(e.Message); } //

        Console.WriteLine("Zůstatek je " + u1.balance);
    }
}
