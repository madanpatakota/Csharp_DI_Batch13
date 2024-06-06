using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsNamespace
{
    public interface ITransaction
    {
        void Execute();
    }


    //ITransaction tr = new ITransaction();  //wrong

    //ITransaction tr = new SimpleTrancation(); //right
    //ITransaction tr1 = new ComplexTrancation(); //right

    //SimpleTrancation tr = new SimpleTrancation(); //right
    //ComplexTrancation tr1 = new ComplexTrancation(); //right

    //SimpleTrancation tr = new ComplexTrancation(); //wrong
    //ComplexTrancation tr = new SimpleTrancation(); //wrong


    public class SimpleTrancation : ITransaction
    {
        public void Execute()
        {
            Console.WriteLine("Execute simple Transaction!!!");
        }
    }

    public class ComplexTrancation : ITransaction
    {
        public void Execute()
        {
            Console.WriteLine("Execute Complex Transaction!!!");
        }
    }

    public class TransactionProcessor
    {
        private ITransaction _transaction; //Member
        public TransactionProcessor(ITransaction transaction) //Member
        {
            _transaction = transaction;
        }

        //private string _firstName; //Member
        //public TransactionProcessor(string fir) //Member
        //{
        //    _firstName = fir;
        //}

        public void ProcessTransaction()
        {
            try
            {
                Console.WriteLine("Processing transaction...");
                _transaction.Execute();
                Console.WriteLine("Trasaction has completed Successfully...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server down. please try after 24 hours......And Exeception message is : {ex.Message}");
            }
        }
    }


    //class TestClass
    //{
    //    public TestClass(string firsname)
    //    {

    //    }
    //}

    public class Program
    {
        static void Main()
        {

            //TestClass ts = new TestClass("John");



            // Setting up Dependency Injection manually. Please focus here the way how we are reference 
            // class with interface.


            ITransaction transaction = new SimpleTrancation();//You can do it.
            
            TransactionProcessor transactionProcessor = 
                                        new TransactionProcessor(transaction);

            transactionProcessor.ProcessTransaction();

            Console.WriteLine("******************************************************");


            // Setting up Dependency Injection manually for a different type of transaction
            ITransaction ctransaction = new ComplexTrancation();//You can do it.

            TransactionProcessor ctransactionProcessor =
                                        new TransactionProcessor(ctransaction);

            ctransactionProcessor.ProcessTransaction();


            Console.ReadLine();




        }
    }









}
