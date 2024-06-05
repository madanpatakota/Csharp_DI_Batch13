using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDINamespace
{
    //Angular // APIs (Dependency injection patern) 10 days
    public interface IAccount
    {
        decimal GetBalance();
    }

    public class BankAccount : IAccount
    {
        private decimal _balance;
        public BankAccount(decimal balance)
        {
            _balance = balance;
        }
        public decimal GetBalance()
        {
            return _balance;
        }
    }


    // This is real time....
    public class BankService
    {
        private IAccount _account;
        public BankService(IAccount account)
        {
            _account = account;
        }

        public void DisplayBalance()
        {
            //interface i will pass the BankAccount related ref 
            //IAccount account = new BankAccount();
            //account.GetBalance();
            decimal balance = _account.GetBalance();
            Console.WriteLine($"Account Balance : {balance}");
        }
    }


    //f10 and f11 
    public class Program
    {
        static void Main()
        {
            IAccount account = new BankAccount(1000);
            account.GetBalance();

            //account is holding the BankAccount reference.
            BankService bankService = new BankService(account);
            bankService.DisplayBalance();
        }
    }



}
