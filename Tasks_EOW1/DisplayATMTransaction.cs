using System;
using System.Collections;

namespace DisplayATMTransaction
{
    class Program
    {

        private interface TransactionList
        {
            void ShowTransaction();
        }

        public class DetailedTransaction : TransactionList
        {
            private int transNum { get; set; }
            private string transDate { get; set; }
            private double transAmt { get; set; }

            public DetailedTransaction(int num, string date, double amt)
            {
                this.transNum = num;
                this.transDate = date;
                this.transAmt = amt;
            }

            public void ShowTransaction()
            {
                Console.WriteLine("Transaction Number: {0}", transNum);
                Console.WriteLine("Transaction Date: {0}", transDate);
                Console.WriteLine("Transaction Amount: {0}", transAmt.ToString("C"));
            }

            public int GetTransactionNum()
            {
                return transNum;
            }
        }

        static void Main(string[] args)
        {
            DetailedTransaction t1 = new DetailedTransaction(1, "16/04/2022", 1000);
            DetailedTransaction t2 = new DetailedTransaction(2, "18/04/2022", 5000);
            DetailedTransaction t3 = new DetailedTransaction(3, "21/04/2022", 2500);

            Hashtable transactions = new Hashtable();

            transactions.Add(t1.GetTransactionNum(), t1);
            transactions.Add(t2.GetTransactionNum(), t2);
            transactions.Add(t3.GetTransactionNum(), t3);

            Console.WriteLine("Please choose from the following transaction numbers to display: ");
            foreach(DictionaryEntry items in transactions)
            {
                Console.WriteLine(items.Key);
            }
            int selection = Convert.ToInt32(Console.ReadLine());

            void DisplayTransaction(int input)
            {
                switch (input)
                {
                    case 1:
                        t1.ShowTransaction();
                        break;

                    case 2:
                        t2.ShowTransaction();
                        break;
                    case 3:
                        t3.ShowTransaction();
                        break;
                    default:
                        Console.WriteLine("Transaction number invalid.");
                        break;
                }
            }

            DisplayTransaction(selection);

            Console.ReadLine();
        }
    }
}

