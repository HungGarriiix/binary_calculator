using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet_and_loans.DAO;

namespace wallet_and_loans.Logics
{
    public class BillManager
    {
        public BillManager(User user)
        {
            AuthenedUser = user;
        }

        public IBillDAO BillDataProvider { get; set; }
        public User AuthenedUser { get; set; }

        public void AddBill(Bill bill)
        {
            BillDataProvider.AddBill(bill);
            bill.WalletUsed.DeductBalance(bill.Total);
        }

        public void UpdateBill(Bill bill)
        {
            float old_total = BillDataProvider.GetBillByID(AuthenedUser, bill.ID).Total;
            bill.WalletUsed.AddBalance(old_total);  // return the money first
            BillDataProvider.UpdateBill(bill);
            bill.WalletUsed.DeductBalance(bill.Total);  // then add the newly bill money
        }

        public Bill GetBillByID(int id)
        {
            return BillDataProvider.GetBillByID(AuthenedUser, id);
        }

        public List<Bill> GetBills(BillFilter filter)
        {
            return BillDataProvider.GetUserBillsByFilter(AuthenedUser, filter);
        }

        public void RemoveBill(Bill bill) 
        {
            BillDataProvider.DeleteBill(bill);
            bill.WalletUsed.AddBalance(bill.Total);
        }
    }
}
