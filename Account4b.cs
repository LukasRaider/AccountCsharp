using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account4b;
class Person
{
    public String name;
    public int age;
    public List<Account> myAccounts = new List<Account>();    //
    public int countOfAccounts = 0;                          //při foreach není nutné
    public Person(String name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void writeAccounts()
    {
        int suma = 0;
        for (int i = 0; i < countOfAccounts; i++)
        {
            Console.Write(i + ". " + myAccounts[i]);
            Console.Write($"owner: {myAccounts[i].owner.name} balance: {myAccounts[i].balance}");
            suma += myAccounts[i].balance;
        }
        Console.WriteLine($"\n Celkem {suma} Kč");
    }
    public void writeAccounts2()
    {                                        //2. možnost
        int i = 0;                                                    //2
        foreach (Account u in myAccounts)
        {                                //2
            Console.WriteLine($"{i++}. owner: {u.owner.name} balance: {u.balance}");//2
        }
    }
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < countOfAccounts; i++)
        {
            s += $"{myAccounts[i].ToString()} \n";
        }
        return s;
    }
}
class Account
{
    public int balance;
    public Person owner;
    public Account(Person majitel, int castka)
    {
        owner = majitel; balance = castka;
        majitel.myAccounts.Add(this);                           //
        majitel.countOfAccounts++;                                  //při foreach není nutné
    }
    public void insertInto(int c)
    {
        balance += c;
    }
    public void writeBalance()
    {
        Console.WriteLine($"owner účtu: {owner.name}, na účtu je: {balance}");
    }
    public void transferTo(Account ucet, int castka)
    {
        ucet.balance += castka;
        balance -= castka;
    }
    public override string ToString()
    {
        return $"{this.owner.name}'s account has a balance of {this.balance}";
    }
}
class TestAccount
{
    public static void Mainx(string[] args)
    {
        Person o1 = new Person("Petr", 29); Person o2 = new Person("Jan", 50);
        Account u1 = new Account(o1, 100); Account u2 = new Account(o2, 100); Account u3 = new Account(o1, 200);
        u1.insertInto(100); u2.insertInto(100);
        u1.transferTo(u2, 50);
        u1.writeBalance(); u2.writeBalance();
        Console.WriteLine(o1.myAccounts[0].balance);
        o1.writeAccounts();
        o1.writeAccounts2();                 //
    }
}
