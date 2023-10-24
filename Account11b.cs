using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account11b;
class Account
{
    int balance;
    public void insertInto(int castka)
    {    //zmizel try a catch
        if ((balance + castka) < 0) throw new MaloPenezException(
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
            throw new MaloPenezException(
                "Na účtu není pro PŘEVOD dostatek peněz,je zde " + balance + "Kč");
        if (castka < 0)
            throw new MaloPenezException("Nesmíš vysávat cizí účty");
        if (castka == 0)
            throw new MaloPenezException("Nelze převádět 0 Kč.");
        if (this == ucet)
            throw new MaloPenezException("Nelze převádět sám sobě.");

        ucet.balance += castka;
        balance -= castka;
    }
    class MaloPenezException : Exception
    { }
    class vyberZcizihoUctu : Exception { }

}



    public static void Mainx(String[] args)
    {
        int amount = 0; bool chyba;
        Account u1 = new Account(); Account u2 = new Account();
        Console.Write("Na účtu je " + u1.balance + " Kč. Zadej vklad (výběr je záporný) (celé číslo)");
        do
        {
            amount = int.Parse(Console.ReadLine());

            try
            {                                                                   //
                u1.insertInto(amount);
                chyba = false;
            }                                                                       //
            catch (MaloPenezException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                chyba = true;
            } //   
        }
        while (chyba);
        Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
        do
        {
            amount = int.Parse(Console.ReadLine());

            try
            {                                                                   //
                u1.transferTo(u2, amount);
                chyba = false;
            }                                                                       //
            catch (MaloPenezException e) { Console.WriteLine(e.Message); } //

            Console.WriteLine("Zůstatek je " + u1.balance);
            chyba = true;
        }
        while (chyba);
    }
}
