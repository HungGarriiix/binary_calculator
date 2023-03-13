using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace binaries
{
    public class HexToIntCal : ICal
    {
        private readonly string _hex;
        private int _int_result;

        public HexToIntCal(string input)
        {
            CheckInput(input);

            _hex = input;
            _int_result = 0;

            Calculate();
        }

        public string Input { get { return _hex; } }
        public string Result { get { return _int_result.ToString(); } }

        public bool CheckInput(string input)
        {
            if (input == string.Empty)
                throw new ArgumentException("The input is empty.");

            Regex rx = new Regex(@"[A-F]|[0-9]+", RegexOptions.None); // find character in range A-F and 0-9

            /*foreach(char c in input)
            {
                if (!rx.IsMatch(input))
                    return false;
            }
            return true;*/
            return rx.IsMatch(input);
        }

        private int ConvertHexCharToInt(char c)
        {
            int c_int = Convert.ToInt32(c); // convert to ASCII alternatives for comparisons
            if (c_int >= 48 && c_int <= 57) // check if c is 0-9
                return c_int - 48;  // value: 0 - 9

            if (c_int >= 65 && c_int <= 70) // check if c is A-F
                return c - 55;      // value: 10 - 15

            return 0; // found nothing (unlikely)
        }

        public void Calculate()
        {
            int hex_base = 1;
            for (int i = _hex.Length - 1; i >= 0; i--)
            {
                _int_result += ConvertHexCharToInt(_hex[i]) * hex_base;
                hex_base *= 16;
            }
        }
    }
}
