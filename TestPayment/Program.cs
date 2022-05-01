using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPayment
{
    class Program
    {
        static void Main(string[] args)
        {
            Payee payee = new Payee();
            PayeeMgr payeeMgr = new PayeeMgr();

            ArrayList array = new ArrayList();

            char ch;
            do
            {

                payee = payeeMgr.StoreData(payee);

                array.Add(payee);

                payeeMgr.ShowData(payee);
                Console.WriteLine("Do you want to continue");
                ch = Convert.ToChar(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');

            foreach (Payee data in array)
            {
                payeeMgr.ShowData(data);
            }
        }
    }
}
