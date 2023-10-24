using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account4;
class Person
{
    public String name;
    public int age;
    public Account[] myAccounts = new Account[10];                              //1
    public int countOfAccounts = 0;                                           //1
    public Person(String name, int age)
    {
        this.name = name;
        this.age = age;
        //this.myAccounts = new Account[10];
        
    }
    
    public void writeAccounts()
    { //lze doplnit if(countOfAccounts>=1)...else Write("Nemá účet")
        int suma = 0;//3
        Console.WriteLine($"Ucty majitele {name}:");
        for (int i = 0; i < countOfAccounts; i++)
        {                             //2
            Console.Write(i + ". " + myAccounts[i]);                          //2  
            Console.Write($"owner: {myAccounts[i].owner.name} balance: {myAccounts[i].balance}");//2
            suma += myAccounts[i].balance;                                       //3
        }                                                                 //2
        Console.WriteLine("\n Celkem " + suma + " Kč");                   //3
    }    //2
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
        owner.myAccounts[majitel.countOfAccounts] = this;
        owner.countOfAccounts++;      //1 nebo majitel.countOfAccounts
    }
    public void insertInto(int castka)
    {
        balance += castka;
    }
    public void writeBalance()
    {
        Console.WriteLine("owner: " + owner.name + ", balance: " + balance);
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
class testAccount
{
    public static void Mainx(string[] args)
    {
        Person o1 = new Person("Petr", 29); Person o2 = new Person("Jan", 50);
        Account u1 = new Account(o1, 100);
        Account u2 = new Account(o2, 100);
        Account u3 = new Account(o1, 200); //
        u1.insertInto(100); u2.insertInto(100);
        u1.transferTo(u2, 50);
        Console.Write($"{nameof(u1)}:"); u1.writeBalance(); u2.writeBalance();
        Console.WriteLine(o1.myAccounts[0].balance);  //2
        o1.writeAccounts();                            //2
                                                       // Console.WriteLine(o1.ToString());
    }
}
