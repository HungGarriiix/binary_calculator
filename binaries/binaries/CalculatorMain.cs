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
        private readonly ICalCollection _calculations;
        private readonly ICalIterator _cals;

        public CalculatorMain()
        {
            AddModeNames();
            _calculations = new CCList();
            _cals = _calculations.GetForwardIterator();
            _calculations.CollectionChanged += SetupMainIterator;
        }

        public ICalCollection CollectionCal { get { return _calculations; } }

        public ICalIterator MainCal { get { return _cals; } }

        private void AddModeNames()
        {
            mode_names.Add("<none>");
            mode_names.Add("Binary -> Integer");
            mode_names.Add("Integer -> Binary");
            mode_names.Add("Integer -> Hexadecimal");
            mode_names.Add("Hexadecimal -> Integer");
        }

        public string[] GetModes()
        {
            return mode_names.ToArray();
        }

        private void SetupMainIterator(object sender, EventArgs e)
        {
            _cals.RecentCalculation();
        }
    }
}
