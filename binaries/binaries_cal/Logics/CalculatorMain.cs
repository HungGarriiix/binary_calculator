using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries_cal.Logics
{
    // Each users get 1 instance of CalculatorMain to interact with
    public class CalculatorMain
    {
        // Normal initialization
        private readonly List<string> mode_names = new List<string>();
        private readonly ICalCollection _calculations;
        private readonly ICalIterator _cals;
        private readonly string _user;  // This might be changed with different type

        public CalculatorMain(string username)
        {
            AddModeNames();
            _user = username;
            _calculations = new CCList();
            _cals = _calculations.GetForwardIterator();
            _calculations.CollectionChanged += SetupMainIterator;
        }

        public ICalCollection CollectionCal { get { return _calculations; } }

        public ICalIterator MainCal { get { return _cals; } }

        public string User { get { return _user; } }

        private void AddModeNames()
        {
            mode_names.Add("<none>");
            mode_names.Add("Binary -> Integer");
            mode_names.Add("Integer -> Binary");
            mode_names.Add("Integer -> Hexadecimal");
            mode_names.Add("Hexadecimal -> Integer");
            mode_names.Add("Binary -> Hexadecimal");
            mode_names.Add("Hexadecimal -> Binary");
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
