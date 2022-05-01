using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class TransactionDetails
    {
        
        
        public string TransactionId { get; set; }

        public double Amount { get; set; }
        public string Date { get; set; }

        public override bool Equals(object obj)
        {
            TransactionDetails transaction = obj as TransactionDetails;
            return (obj != null) && (this.TransactionId == transaction.TransactionId)
                && (this.Amount == transaction.Amount) &&(this.Date==transaction.Date);
        }
    }
}
