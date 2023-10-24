using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account2;
class Person
{                     //
    public String name;            //
    public int age;                 //
    public Person() { }              //
    public Person(String name, int age)
    {//
        this.name = name;           //
        this.age = age;               //
    }
}
class Account
{
    public int balance;
    public Person owner;                  //
    public Account() { }
    public Account(Person osoba, int castka)
    {   //
        owner = osoba;                  //
        balance = castka;                     //
    }                               //
    public void insertInto(int c)
    {
        balance += c;
    }
    public void writeBalance()
    {
        Console.WriteLine($"owner: {owner.name}, balance: {balance}");  //
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
    //public void transferTo(Account u) {   //
    //  transferTo(u, balance);              //
    //}                                 //
}
class TestAccount
{
    public static void Mainx(string[] args)
    {
        Account u = new Account();
        //u.writeBalance();// havarovalo v metodě writeBalance
        //Console.WriteLine(u.owner.age); //tohle taky havaruje
        Console.WriteLine(u.balance);// zde už nehavaruje

        Person o1 = new Person("Petr", 29); Person o2 = new Person("Jan", 50);  //
        Account u1 = new Account(o1, 100);              //
        Account u2 = new Account(o2, 100);              //

        u1.insertInto(100); u2.insertInto(100);
        u1.transferTo(u2, 50);
        u1.writeBalance(); u2.writeBalance();
        writeBalance2(u1, u2);       //
        Console.WriteLine(u2.ToString());
        //u1.transferTo(u2);                        //
        //u1.writeBalance(); u2.writeBalance(); //
        Console.WriteLine(u1.owner.name);
        static void writeBalance2(Account uu1, Account uu2)
        { //
            uu1.writeBalance(); uu2.writeBalance();             //
        }
    }
    //
}