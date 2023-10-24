using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Account2
{
    class Account 
    {
        public int balance;
        public Person owner;
        public void insertInto(int amount)
        {
            balance += amount;
        }
        public void SetPerson(String Name,int Vek)
        { 
            owner.name= Name;
            owner.vek= Vek;
        }
       
        public void writeBalance()
        {
            Console.WriteLine($"Na účtu od {owner.name} je: {balance}");
        }
        public void transferTo(Account ucet, int castka)
        {
            ucet.balance += castka;
            this.balance -= castka;
        }
        

    }
    class Person 
    {
        public string name;
        public int vek;
        
    }
    class TestAccount
    {
        public static void Mainx(string[] args)
        {
            Account u1 = new Account();
            Account u2 = new Account();
            
            u1.insertInto(100); u2.insertInto(100);
            u1.SetPerson("Jana",25); u2.SetPerson("Ana", 30);
            u1.transferTo(u2, 50);
            u1.writeBalance(); u2.writeBalance();
            u1.insertInto(-10);
            u1.transferTo(u2, 10);
            Console.Write($"{nameof(u1)}:");
            u1.writeBalance();
            Console.Write($"{nameof(u2)}:");
            u2.writeBalance();
        }
    }
}
