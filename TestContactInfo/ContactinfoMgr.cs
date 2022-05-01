using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestContactInfo
{
    public class InvalidMobileNo : Exception
    {
        public InvalidMobileNo(string msg) : base(msg)
        {

        }
    }

    public class InvalidWebsite : Exception
    {
        public InvalidWebsite(string msg) : base(msg)
        {

        }
    }
    public class InvalidAddress : Exception
    {
        public InvalidAddress(string msg) : base(msg)
        {

        }
    }
    class ContactinfoMgr
    {
        public ContactInfo StoreData(ContactInfo contact)
        {
            string address, city, state, country, mobileNo, emailId;

            Console.WriteLine("Enter Address :");
            address = Console.ReadLine();

            address = ToUpperCase(address);

            contact.Address = address;

            Console.WriteLine("Enter city :");
            city = Console.ReadLine();

            city = ToTitleCase(city);
            try
            {
                if (city == null)
                    throw new InvalidAddress("Address is not Valid");
            }catch(InvalidAddress exception)
            {
                Console.WriteLine(exception);
            }

            contact.City = city;

            Console.WriteLine("Enter state :");
            state = Console.ReadLine();

            state = ToTitleCase(state);
            try
            {
                if (state == null)
                    throw new InvalidAddress("Address is not Valid");
            }
            catch (InvalidAddress exception)
            {
                Console.WriteLine(exception);
            }

            contact.State = state;

            Console.WriteLine("Enter country :");
            country = Console.ReadLine();

            country = ToTitleCase(country);
            try
            {
                if (country == null)
                    throw new InvalidAddress("Address is not Valid");
            }
            catch (InvalidAddress exception)
            {
                Console.WriteLine(exception);
            }

            contact.Country = country;

            Console.WriteLine("Enter Mobile Number :");
            mobileNo = Console.ReadLine();

            try
            {
                if (!ValidatePhoneNo(mobileNo))
                    throw new InvalidMobileNo("Mobile is not Valid");
            }
            catch (InvalidMobileNo exception)
            {
                Console.WriteLine(exception);
            }

            contact.MobileNo = mobileNo;

            Console.WriteLine("Enter Email id :");
            emailId = Console.ReadLine();

            try
            {
                if (!ValidateEMailId(emailId))
                    throw new InvalidEmailId("Website is not Valid");
            }
            catch (InvalidEmailId exception)
            {
                Console.WriteLine(exception);
            }
            contact.EmailId = emailId;

            return contact;
        }

        private static bool ValidateEMailId(string emailId)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(emailId))
                return true;
            return false;
        }

        private static bool ValidatePhoneNo(string mobileNo)
        {
            Regex regex = new Regex(@"^([\+]?91[-]?|[0])?[1-9][0-9]{9}$");

            if (regex.IsMatch(mobileNo))
                return true;
            return false;
        }
        private static string ToTitleCase(string str)
        {
            if (str.Any(char.IsDigit))
                return null;
            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToTitleCase(str));

        }

        private static string ToUpperCase(string str)
        {

            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToUpper(str));

        }
        public void ShowData(ContactInfo contact)
        {
            Console.WriteLine("Address   :"+contact.Address);
            Console.WriteLine("City      :"+contact.City);
            Console.WriteLine("State     :"+contact.State);
            Console.WriteLine("Country   :"+contact.Country);
            Console.WriteLine("Mobile No :"+contact.MobileNo);
            Console.WriteLine("Email Id  :"+contact.EmailId);

            Console.WriteLine();
        }
    }
}
