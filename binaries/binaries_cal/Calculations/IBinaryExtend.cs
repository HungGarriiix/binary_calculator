﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries_cal.Calculations
{
    public interface IBinaryExtend
    {
        string GetExtendedBinary(int length);
        int GetBinaryChainLength(string input, int required_length);
    }
}
