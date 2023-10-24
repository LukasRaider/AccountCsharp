using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account8;
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
    public void writeBalanceInDollars(int kurz)
    {                         //
        try
        {                                                             //2
            Console.WriteLine($"Na účtu je: {balance / kurz} dolarů");    //
        }                                                                 //2
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        } //2
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }   //3 nesmí být první
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }                                                                   //Ještě výš je Exception 
    public void writeBalanceInDollarsDouble(double kurz)
    {                //4
        try
        {   //4
            if (kurz == 0)
                throw new DivideByZeroException();               //4
            else                                                            //4
                Console.WriteLine($"Na účtu je: {balance / kurz} dolarů");  //4
        }                                                                 //4
        catch (DivideByZeroException e) { Console.WriteLine(e.Message + " (reálnou)"); } //4
        Console.WriteLine(balance / kurz);
    }

    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account();
        Console.Write("Zadej částku pro vložení/výběr peněz (celé číslo)");
        amount = int.Parse(Console.ReadLine());
        u1.insertInto(amount);
        Console.WriteLine($"Zůstatek je {u1.balance}");
        u1.writeBalanceInDollars(0);                                          //
        u1.writeBalanceInDollarsDouble(0.0);                                  //4
    }
}
