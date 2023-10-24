using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account3;
class Person
{
    public String name;
    public int age;
    public Account myAccount;            //
    public Person(String jmeno, int age)
    {
        this.name = jmeno;
        this.age = age;
    }
}
class Account
{
    int balance;
    public Person owner;
    public Account(Person majitel, int castka)
    {
        this.owner = majitel;
        balance = castka;
        this.owner.myAccount = this;               //
    }
    public void insertInto(int castka)
    {
        balance += castka;
    }
    public void writeBalance()
    {
        Console.WriteLine($"owner: {owner.name}, balance: {balance}");
    }
    public void transferTo(Account ucet, int castka)
    {
        ucet.balance += castka;
        balance -= castka;
    }
    public override string ToString()
    {
        return $"{this.owner.name}'s account \t {balance}";
    }
}
class TestAccount
{
    public static void Mainx(string[] args)
    {
        Person o1 = new Person("Petr", 29); Person o2 = new Person("Jan", 50);
        Account u1 = new Account(o1, 100);
        Account u2 = new Account(o2, 100);
        u1.insertInto(100);
        u2.insertInto(100);
        u1.transferTo(u2, 50);
        u1.writeBalance();
        u2.writeBalance();
        o1.myAccount.writeBalance();            //
    }
}
