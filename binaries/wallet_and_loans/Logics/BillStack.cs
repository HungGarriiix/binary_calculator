using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class BillStack: ItemStack
    {
        public BillStack(string name, int quantity, float totalValue)
            : base(name, quantity)
        {
            TotalPrice = totalValue;
        }

        public override float SinglePrice { get => TotalPrice / Quantity; set => throw new NotImplementedException(); }
        // only get is allowed on SinglePrice
        public override float TotalPrice { get; set; }
    }
}
