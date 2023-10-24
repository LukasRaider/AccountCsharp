using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountVlastni9;
class MaloPenezException : Exception { }                      //
class VyberZCizihoUctuException : Exception { }               //2
class PrevodNulyException : Exception { }                     //2

class Account
{
    int balance;
    public void insertInto(int amount)
    {
        try
        {                                                     //
            if ((balance + amount) < 0) throw new MaloPenezException();//
            balance += amount;
        }
        catch (MaloPenezException e) { Console.WriteLine(e.StackTrace + " Na účtu není pro výběr dostatek peněz"); }  //
    }
    public void writeBalance()
    {
        Console.WriteLine("Na účtu je: " + balance);
    }
    public void transferTo(Account u, int c)
    {
        try
        {                                                     //   
            if ((balance - c) < 0) throw new MaloPenezException();     //
            if (c < 0)                                              //2
                throw new VyberZCizihoUctuException();                //2
            if (c == 0)                                             //2
                throw new PrevodNulyException();                      //2

            u.balance += c;
            balance -= c;
        }
        catch (MaloPenezException e) { Console.WriteLine(e.Message + "Na účtu není pro převod dostatek peněz"); }//
        catch (VyberZCizihoUctuException e) { Console.WriteLine(e.Message + "Nesmíš vysávat cizí účty"); }       //2
        catch (PrevodNulyException e) { Console.WriteLine(e + "Nelze převádět 0 Kč."); }                 //2

    }

    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account(); Account u2 = new Account();
        Console.Write("Na účtu je " + u1.balance + " Kč. Zadej vklad (výběr je záporný) (celé číslo)");
        amount = int.Parse(Console.ReadLine());
        u1.insertInto(amount);
        Console.Write("Na účtu je " + u1.balance + " Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
        amount = int.Parse(Console.ReadLine());
        u1.transferTo(u2, amount);
        Console.WriteLine("Zůstatek je " + u1.balance);
    }
}

