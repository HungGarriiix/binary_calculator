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

        public string Name { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public float TotalPrice { get; set; } = 0;
        public float SinglePrice { get { return TotalPrice / Quantity; } }
        // When people assigning prices for the items, they tend to get the total of price written on the bill
        //, so only the total price is edittable
        
    }
}
