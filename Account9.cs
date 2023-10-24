using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account9;
class Account
{
    int balance;
    public void insertInto(int castka)
    {
        try
        {                                                                   //2
            if ((balance + castka) < 0)
            {                                              //1
                throw new ArgumentOutOfRangeException(
                    $"Na účtu není pro VÝBĚR dostatek peněz, je zde {balance}Kč");
            }//1
            balance += castka;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        } //2
    }
    public void writeBalance()
    {
        Console.WriteLine("Na účtu je: " + balance);
    }
    public void transferTo(Account ucet, int castka)
    {
        try
        {                                                                   //3   
            if ((balance - castka) < 0)                                                   //3
                throw new ArgumentOutOfRangeException(
                    $"Na účtu není pro PŘEVOD dostatek peněz,je zde {balance} Kč");//3
            if (castka < 0)                                                            //4
                throw new ArgumentOutOfRangeException("Nesmíš vysávat cizí účty");  //4
            if (castka == 0)                                                           //4
                throw new ArgumentOutOfRangeException("Nelze převádět 0 Kč.");      //4
            if (this == ucet)                                                        //4
                throw new ArgumentOutOfRangeException("Nelze převádět sám sobě.");//4
            ucet.balance += castka;
            this.balance -= castka;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        } //3
    }
    //public void writeBalanceInDollars(int kurz) {}                            //

    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account(); Account u2 = new Account();
        Console.Write($"Na účtu je {u1.balance} Kč. Zadej vklad (výběr je záporný) (celé číslo)");
        amount = int.Parse(Console.ReadLine());
        u1.insertInto(amount);
        Console.Write($"Na účtu je {u1.balance} Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
        amount = int.Parse(Console.ReadLine());
        u1.transferTo(u2, amount);
        Console.WriteLine($"Zůstatek je {u1.balance}");
        u1.transferTo(u1, 100);
        //u1.writeBalanceuVDolarech(0);                              //
    }
}
