using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class Spending
    {
        public Spending()
        {

        }

        public Person Loaned { get; set; }
        public List<ItemStack> ItemList { get; set; }
        public float MoneySpent { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }

        public void ConfirmPayment()
        {

        }

        public void UpdatePayment()
        {

        }
    }
}
