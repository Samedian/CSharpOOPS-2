using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Current
{
    class Company
    {
        
        public string CompanyName { get; set; }
        public string TypeofBussiness { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }


        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            Company company = value as Company;
            return (company != null) && (company.CompanyName == this.CompanyName) 
                && (this.TypeofBussiness == company.TypeofBussiness) && (this.ContactName==company.ContactName)
                && (this.ContactName==company.ContactName);
        }


    }
}
