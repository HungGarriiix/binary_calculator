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

        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public List<ItemStack> Items { get; private set; } = new List<ItemStack>();
        public float Total { get { return Items.Sum(item => item.TotalPrice); } }
        public Wallet WalletUsed { get; set; } = null;  // might be changed to default wallet
        public User Owner { get; set; } = null;
        
        public void AddItemToBill(ItemStack item)
        {
            Items.Add(item);
        }

        public void RemoveItemFromBill(ItemStack item)
        {
            Items.Remove(item);
        }

        public ItemStack GetItemFromBill(string name)
        {
            return Items.Find(item => item.Name == name);
        }

        private void DeductWalletBalance()
        {
            WalletUsed.DeductBalance(Total);
        }
    }
}
