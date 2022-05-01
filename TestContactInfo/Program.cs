using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestContactInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            ContactInfo contactInfo = new ContactInfo();
            ContactinfoMgr contactinfoMgr = new ContactinfoMgr();

            ArrayList array = new ArrayList();

            char ch;
            do
            {
                contactInfo = contactinfoMgr.StoreData(contactInfo);

                array.Add(contactInfo);

                contactinfoMgr.ShowData(contactInfo);
                
                Console.WriteLine("Do you want to continue");
                ch = Convert.ToChar(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');

            foreach (ContactInfo contact in array)
            {
                contactinfoMgr.ShowData(contact);
            }

            Console.ReadKey();
        }
    }
}
