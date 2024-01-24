using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class BillManager
    {
        public BillManager(User user) 
        {

        }

        public User MainUser { get; private set; }
        public List<Bill> BillList { get; set; } = new List<Bill>();

        public void AddBill(Bill bill)
        {
            BillList.Add(bill);
            bill.WalletUsed.DeductBalance(bill.Total);
        }

        public void RemoveBill(Bill bill) 
        {
            BillList.Remove(bill);
            bill.WalletUsed.AddBalance(bill.Total);
        }
    }
}
