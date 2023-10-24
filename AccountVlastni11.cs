using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountVlastni11;
class MaloPenezException : Exception
{
    public MaloPenezException(String s)                                        //
      : base(s)
    {      //konstruktor s parametrem typu String volá nadřazenou výjimku
    }                                                                          //
}
class Account
{
    int balance;
    public void insertInto(int amount)
    {
        if ((balance + amount) < 0)
        {
            throw new MaloPenezException(
                     $"Na účtu není pro VÝBĚR dostatek peněz,je zde {balance}Kč"); //
        }
        balance += amount;
    }
    public void writeBalance()
    {
        Console.Write("Na účtu je: " + balance);
    }
    public void transferTo(Account u, int c)
    {
        if ((balance - c) < 0) throw new MaloPenezException(
                $"Na účtu není pro PŘEVOD dostatek peněz,je zde {balance}Kč"); //
        u.balance += c;
        balance -= c;
    }
    public static void Mainx(String[] args)
    {
        int amount = 0;
        Account u1 = new Account(); Account u2 = new Account();
        do
        {
            Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej vklad (výběr je záporný) (celé číslo)");
            amount = int.Parse(Console.ReadLine());
            try
            {
                u1.insertInto(amount);
                break;
            }
            catch (MaloPenezException e) { Console.WriteLine(e.Message); }
        } while (true);
        bool ok = true;
        do
        {
            Console.Write("\nNa účtu je " + u1.balance + " Kč. Zadej částku převáděnou na cizí účet (kladné celé číslo)");
            amount = int.Parse(Console.ReadLine());
            try
            {
                u1.transferTo(u2, amount);
            }
            catch (MaloPenezException e) { Console.WriteLine(e.Message); ok = false; }
        } while (ok == false);
        Console.WriteLine("Zůstatek je " + u1.balance);
    }
}
