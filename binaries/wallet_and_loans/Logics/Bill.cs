using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class Bill
    {
        public Bill() 
        {

        }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public float Total { get; set; }
        public Wallet WalletUsed { get; set; }

    }
}
