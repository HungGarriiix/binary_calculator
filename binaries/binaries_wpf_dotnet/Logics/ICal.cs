using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries_wpf_dotnet.Logics
{
    public interface ICal
    {
        string Result { get; }
        string Input { get; }
        string ModeTitle { get; }
        string ResultFull { get; }
        void Calculate();
        bool CheckInput(string input);
    }
}
