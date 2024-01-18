using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class Loan
    {

        public Loan()
        {

        }

        public Bill BillToLoan { get; set; }
        public List<Spending> Spendings { get; set; }
        public bool PaymentCompleted { get; set; }

        public void AddSpending()
        {

        }

        public void DeleteSpending()
        {

        }

        public void UpdateSpending()
        {

        }
    }
}
