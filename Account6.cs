using Account5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account6;
class Date
{
    public int day, month, year;            //
    public Date(int den, int mesic, int rok)
    {    //
        day = den; month = mesic; year = rok;         //
    } //
}
class Person
{
    public String name;
    public Date dateOfBirth;                   //
    public Account[] accounts = new Account[10];
    public int countOfAccounts = 0;
    public Person(String name, Date datnar)
    { //    
        this.name = name;
        dateOfBirth = datnar;                         //
    }

    public Person(String name, int den, int mesic, int rok)
        : this(name, new Date(den, mesic, rok))  //4  
    {                                    //3   
                                         //this.name = name;                //3
                                         // dateOfBirth = new Date(den, mesic, rok);       //3
                                         // dateOfBirth.day = den;                  //výjimka za běhu, NullReferenceException
                                         // dateOfBirth.month = mesic;                //výjimka za běhu
                                         //  dateOfBirth.year = rok;                  //výjimka za běhu
    }                                    //3

    public void writeAccounts()
    {
        Console.WriteLine(this.dateOfBirth.year);
        for (int i = 0; i < countOfAccounts; i++)
        {
            Console.WriteLine($"{i}. účet: {accounts[i]}");
            //Console.WriteLine(" se zůstatkem: "+accounts[i].balance); 
            accounts[i].writeBalance();
        }
    }
}
class Account
{
    public int balance;
    public Person owner;
    public Account(Person majitel, int castka)
    {
        owner = majitel; balance = castka;
        majitel.accounts[majitel.countOfAccounts] = this;
        majitel.countOfAccounts++;
    }
    public void insertInto(int castka)
    {
        balance += castka;
    }
    public void writeBalance()       //na dalším řádku je změna
    {
        Console.WriteLine($"vlastník účtu: {owner.name} je starý {DateTime.Today.Year - owner.dateOfBirth.year} let, na účtu je: {balance}");
    }
    public override string ToString()
    {
        return $"owner: {owner.name}\nbalance: {balance}";
    }
    public void transferTo(Account ucet, int castka)
    {
        ucet.balance += castka;
        balance -= castka;
    }
}
class testAccount
{
    public static void Mainx(string[] args)
    {
        Date d1 = new Date(28, 12, 1988);  //
        /*      Person o1 = new Person("Petr", d1); */
        Person o1 = new Person("Petr", new Date(2, 8, 1999)); //
        Account u1 = new Account(o1, 100);
        Account u2 = new Account(new Person("Jan", new Date(7, 12, 1968)), 100);  //2
        Person o3 = new Person("Romuald", 23, 12, 2000);                         //3
        u1.insertInto(100); u2.insertInto(100);
        u1.transferTo(u2, 50);
        u1.writeBalance(); u2.writeBalance();
        o1.writeAccounts();
        Console.WriteLine(o1.accounts[0]);
        Console.WriteLine($"rok narození ownera účtu1: {u1.owner.dateOfBirth.year}"); //

        //hardcore vytvoreni noveho uctu
        Account u3 = new Account(new Person("Hynek", new Date(10, 10, 2001)), 500);
        Console.WriteLine(o3.dateOfBirth.year.ToString());
    }
}
