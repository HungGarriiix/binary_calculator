using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class CalculatorMain
    {
        // Normal initialization
        private readonly List<string> mode_names = new List<string>();
        private readonly CalHistory cal;

        public CalculatorMain()
        {
            AddModeNames();
            cal = new CalHistory();
        }

        public CalHistory Cal { get { return cal; } }

        private void AddModeNames()
        {
            mode_names.Add("<none>");
            mode_names.Add("Binary -> Integer");
            mode_names.Add("Integer -> Binary");
        }

        public string[] GetModes()
        {
            return mode_names.ToArray();
        }
    }
}
