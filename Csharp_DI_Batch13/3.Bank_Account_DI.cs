using System;
using Microsoft.Extensions.DependencyInjection;
using TransactionsNamespace;

namespace BankAccountDINameSpace
{
    interface IAccountService
    {
        void CreateAccount(string accountHolder);
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance();
    }

    class AccountService : IAccountService
    {
        private string _accountHolder;
        private decimal _balance;
        public void CreateAccount(string accountHolder) //Peter
        {
            //throw new NotImplementedException();
            _accountHolder = accountHolder;
            _balance = 0;
            Console.WriteLine($"Account created for {_accountHolder} and balance is {_balance}.");
        }

        public void Deposit(decimal amount)
        {
            //throw new NotImplementedException();
            _balance = _balance + amount;
            Console.WriteLine($" Total amount is {_balance}.");
        }

        public decimal GetBalance()
        {
            return _balance;
            //throw new NotImplementedException();
        }

        public void Withdraw(decimal amount) //2000
        {
            //1500
            //throw new NotImplementedException();
            if (_balance >= amount)
            {
                _balance = _balance - amount;
                Console.WriteLine($"With draw amount {amount} Now your amount is {_balance}");
            }
            else
            {
                Console.WriteLine($"Insuffcient founds.");
            }
        }
    }


    class Program
    {

        //Register interface along with class by using DI
        static void Main()
        {
            // Create a new ServiceCollection
            ServiceCollection collection = new ServiceCollection();

            //ITransaction ctransaction = new ComplexTrancation();//You can do it.
            // Register services
            collection.AddScoped<IAccountService,AccountService>();

            //Build service collection
            ServiceProvider serviceProvider = collection.BuildServiceProvider();

            //The way you have to get the memebers from AccountService
            IAccountService accountService = serviceProvider.GetService<IAccountService>();
            // Refer the AccountService 


            accountService.CreateAccount("Rajesh");

            accountService.Deposit(20000);

            accountService.Withdraw(1000);

            accountService.Withdraw(3000);

            accountService.Deposit(500);

            accountService.Withdraw(15000);

            accountService.Withdraw(100000);

            Console.ReadLine();

        }

    }

}
