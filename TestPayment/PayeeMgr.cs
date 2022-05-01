using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPayment
{
    class PayeeMgr
    {
        private int payeeId, accountNo;
        private string accName, bank;

        public class MinLengthException : Exception
        {
            public MinLengthException(string msg) : base(msg)
            {

            }
        }

        public class StringContainDigit : Exception
        {
            public StringContainDigit (string msg) : base(msg)
            {

            }
        }
        public Payee StoreData(Payee payee)
        {

             Console.WriteLine("Enter PayeeId");


            try
            {
                payeeId = Convert.ToInt32(Console.ReadLine());
                if (payeeId.ToString().Length < 6)
                    throw new MinLengthException("Min 6 digit required");

            }catch(MinLengthException exception)
            {
                Console.WriteLine(exception);
            }

            payee.PayeeId = payeeId;

            Console.WriteLine("Enter Account Number :");

            try
            {
                accountNo = Convert.ToInt32(Console.ReadLine());

                if (accountNo.ToString().Length != 10)
                    throw new MinLengthException("Min 10 digit required");

            }
            catch (MinLengthException exception)
            {
                Console.WriteLine(exception);
            }

            payee.AccountNo = accountNo;

            Console.WriteLine("Enter Account Name :");
            
            accName = Console.ReadLine();

            accName = ToTitleCase(accName);

            try
            {
                if (accName == null)
                    throw new StringContainDigit("Name doesn't contain digit");
            }catch(StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }

            payee.accountName = accName;

            Console.WriteLine("Enter Bank");
            bank = Console.ReadLine();

            try
            {
                bank = ToUpperCase(bank);
                if (bank == null)
                    throw new StringContainDigit("Name doesn't contain digit");
            }
            catch (StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }
             
            payee.Bank = bank;
            return payee;
        }

        public void ShowData(Payee payee)
        {
            Console.WriteLine("Payee Id     :"+payee.PayeeId);
            Console.WriteLine("Account No   :"+payee.AccountNo);
            Console.WriteLine("Account Name :"+payee.accountName);
            Console.WriteLine("Bank Name    :"+payee.Bank);
        }
        private string ToUpperCase(string str)
        {
            if (str.Any(char.IsDigit))
                return null;

            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToUpper(str));

        }

        private string ToTitleCase(string str)
        {
            if (str.Any(char.IsDigit))
                return null;

            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToTitleCase(str));

        }
    }
}
