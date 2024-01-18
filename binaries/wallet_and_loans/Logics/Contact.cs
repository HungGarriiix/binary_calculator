using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class Contact
    {
        public Contact()
        {

        }

        public ContactType TypeOfContact { get; set; }
        public string ProfileName { get; set; }
        public string ContactInfo { get; set; }
    }
}
