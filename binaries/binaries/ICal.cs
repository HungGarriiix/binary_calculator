using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public interface ICal
    {
        void Calculate();
        string GetInput();
        string GetDefaultResult();
    }
}
