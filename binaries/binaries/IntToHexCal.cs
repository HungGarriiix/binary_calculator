using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class IntToHexCal : ICal
    {
        private readonly int _int;
        private string _hex_result;

        public IntToHexCal(string input)
        {
            if(CheckInput(input))
            {
                _int = Convert.ToInt32(input);
                _hex_result = string.Empty;

                Calculate();
            }
        }

        public string Input { get { return _int.ToString(); } }
        public string Result { get { return _hex_result; } }

        public bool CheckInput(string input)
        {
            if (input == string.Empty)
                throw new ArgumentException("The input is empty.");

            if (!int.TryParse(input, out int result))
                throw new ArgumentException("The input is not an integer.");
            if (result < 0)
                throw new ArgumentException("The input must not be negative.");

            return true;
        }

        private char ConvertIntToHexChar(int i)
        {
            if (i < 0 || i > 15)
                throw new ArgumentException("The number cannot be converted to hexadecimal counterside.");

            // Set of hex chars (Exp: A - 10, B - 11, ..., F - 15)
            char[] hex = { 'A', 'B', 'C', 'D', 'E', 'F' };

            if (i >= 0 && i < 10)
                return Convert.ToChar(i + 48);  // Convert the ints to Unicode characters
            if (i >= 10 && i < 16)
                return hex[i - 10];     // Fit the integer to the index of hex chars array

            return ' ';
        }

        private string FinalizingHexResult(Stack<char> s)
        {
            string result = string.Empty;
            while (s.Count > 0)
                result += s.Pop();
            return result;
        }

        public void Calculate()
        {
            int divided = _int;
            Stack<char> result_mess = new Stack<char>();
            while (divided != 0)
            {
                result_mess.Push(ConvertIntToHexChar(divided % 16));
                divided /= 16;
            }
            _hex_result = FinalizingHexResult(result_mess);
        }
    }
}
