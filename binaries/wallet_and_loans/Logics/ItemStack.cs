using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class ItemStack
    {
        public ItemStack() 
        {
            
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public float SinglePrice { get; set; }
        public float TotalPrice { get; set; }
    }
}
