using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        public class MinLengthException : Exception
        {
            public MinLengthException(string msg) : base(msg)
            {

            }

        }

        public class InvalidDate : Exception
        {
            public InvalidDate(string msg) : base(msg)
            {

            }
        }

        static TransactionDetails AddData(TransactionDetails transaction)
        {

            string transactionId;
            double amount=0;
            string date;

            Console.WriteLine("Enter Transaction Id :");
            transactionId = Console.ReadLine();

            transactionId = ToUpperCase(transactionId);

            transaction.TransactionId = transactionId;

            Console.WriteLine("Enter Amount :");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
                if (amount < 0)
                    throw new MinLengthException("Amount Can't be negative");

            }
            catch (MinLengthException ex)
            {
                Console.WriteLine(ex);
            }


            Console.WriteLine("Enter Date");
            date = Console.ReadLine();

            try
            {
                if (!ValidateDate(date))
                    throw new InvalidDate("Date is Invalid");

            }
            catch (InvalidDate ex)
            {
                Console.WriteLine(ex);
            }


            transaction.Date = date;

            return transaction;
        }

        private static string ToUpperCase(string str)
        {
            
            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToUpper(str));

        }

        private static bool ValidateDate(string date)
        {
            Regex regex = new Regex("^(0[1-9]|[12][0-9]|3[0-1])[-/.](0[1-9]1[0-2][1-9])[-/.](19|20)$");

            if (regex.IsMatch(date))
                return true;

            return false;

        }
        static void Main(string[] args)
        {

            TransactionDetails transaction1 = new TransactionDetails();
            TransactionDetails transaction2 = new TransactionDetails();

            transaction1 = AddData(transaction1);
            transaction2 = AddData(transaction2);
            display(transaction1);
            display(transaction2);

            Console.WriteLine(transaction2.Equals(transaction1));
            Console.ReadKey();
        }

        private static void display(TransactionDetails transaction)
        {
            Console.WriteLine("Transaction Id :" + transaction.TransactionId);
            Console.WriteLine("Amount         :" + transaction.Amount);
            Console.WriteLine("Date           :" + transaction.Date);
        }
    }
}
