using Current;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentCurrent
{
    public class StringContainDigit : Exception
    {
        public StringContainDigit(string msg) : base(msg)
        {

        }
    }

    public class InvalidWebsite : Exception
    {
        public InvalidWebsite(string msg) : base(msg)
        {

        }
    }
    class Current
    {
        public static Company AddCompany(Company company)
        {
            string companyName, typeOfBussiness, website, contactName;


            Console.WriteLine("Enter Company Name :");
            companyName = Console.ReadLine();

            companyName = ConvertName(companyName);

            try
            {
                if (companyName == null)
                    throw new StringContainDigit("Company Name Contain Digit");
            }catch(StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }
            
            company.CompanyName = companyName;

            Console.WriteLine("Enter type of Bussiness :");
            typeOfBussiness = Console.ReadLine();

            typeOfBussiness = ConvertName(typeOfBussiness);

            try
            {
                if (typeOfBussiness == null)
                    throw new StringContainDigit("It Contain Digit");
            }
            catch (StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }
            
            company.TypeofBussiness = typeOfBussiness;

            Console.WriteLine("Enter Website :");
            website = Console.ReadLine();

            try
            {
                if (!ValidateEMailId(website))
                    throw new InvalidWebsite("Invalid website");
            }
            catch (InvalidWebsite exception)
            {
                Console.WriteLine(exception);
            }
            company.Website = website;

            Console.WriteLine("Enter Contact Name :");
            contactName = Console.ReadLine();

            contactName = ConvertName(contactName);

            try
            {
                if (contactName == null)
                    throw new StringContainDigit("Name Contain Digit");
            }
            catch (StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }
            
            return company;
        }


        private static bool ValidateEMailId(string emailId)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(emailId))
                return true;
            return false;
        }
        private static string ConvertName(string accName)
        {

            if (accName.Any(char.IsDigit))
                return null;

            TextInfo text = new CultureInfo("en-US", false).TextInfo;

            return (text.ToTitleCase(accName));


        }

        
        static void Main(string[] args)
        {

            Company company1 = new Company();
            Company company2 = new Company();

            company1 = AddCompany(company1);
            company2 = AddCompany(company2);

            bool equal = company1.Equals(company2);

            Console.WriteLine(equal);


            Console.ReadKey();
        }
    }
}
