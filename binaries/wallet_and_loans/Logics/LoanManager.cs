using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class LoanManager
    {
        public LoanManager() 
        {

        }

        public User MainUser { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
