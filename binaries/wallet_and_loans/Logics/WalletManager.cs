﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class WalletManager
    {
        public WalletManager() 
        {
            
        }

        public User MainUser { get; set; }
        public List<Wallet> Wallets { get; set; }
    }
}
