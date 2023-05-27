using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace binaries
{
    public class HexToBinaryCal : ICal, IBinaryExtend
    {
        private readonly string _hex;
        private string _bin_result;

        public HexToBinaryCal(string input)
        {
            if (CheckInput(input))
            {
                _hex = input;
                _bin_result = string.Empty;

                Calculate();
            }
        }

        public string ModeTitle { get { return "Hexadecimal\u2081\u2086 => Binary\u2082:"; } }
        public string Input { get { return _hex; } }
        public string Result { get { return _bin_result; } }
        public string ResultFull { get { return $"{Input} => {Result}."; } }

        public bool CheckInput(string input)
        {
            if (input == string.Empty)
                throw new ArgumentException("The input is empty.");

            Regex space = new Regex(@"\s");                          // checking for spaces
            Regex lowercase = new Regex(@"[a-z]");                   // checking for lowercase characters
            Regex hex = new Regex(@"[^A-F0-9]+", RegexOptions.None); // find character out of range A-F and 0-9

            if (space.IsMatch(input))
                throw new ArgumentException("Spaces is allowed in the input.");

            if (lowercase.IsMatch(input))
                throw new ArgumentException("Lowercase is prohibited in hexadecimal characters.");

            if (hex.IsMatch(input))
                throw new ArgumentException("The input is not a hexadecimal.");

            return true;
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

        private string Get4BitBinaryFromInt(int i)
        {
            string bin = string.Empty;
            int[] bin_arr = { 8, 4, 2, 1 }; // 4 bits: 2^0 -> 2^3
            int example = i;
            foreach (int b in bin_arr)
            {
                bin += (example - b >= 0) ? "1" : "0";  // if the subtraction result is not negative, register 1 to binary and accept the subtraction
                example -= (example - b >= 0) ? b : 0;  // if the subtraction result is negative, register 0 to binary and not accept the subtraction
            }

            return bin;
        }

        public int GetBinaryChainLength(string input, int required_length)
        {
            int threshold = (input.Length < required_length) ? required_length : input.Length;
            while (threshold % 4 != 0) threshold++;
            return threshold;
        }

        public string GetExtendedBinary(int length)
        {
            // If requested length < result length
            // Get result with min length
            // Otherwise get result with required length
            string refined_result = "";

            // Version 1:
            int added_length = GetBinaryChainLength(_bin_result, length) - _bin_result.Length;
            for (int i = 0; i < added_length; i++)
            {
                refined_result += "0";
            }
            refined_result += _bin_result;

            // Version 2
            /*for (int i = GetBinaryChainLength(_binary_result, length) - 1; i > 0; i--)
            {
                refined_result += (i <= _binary_result.Length - 1) ? _binary_result[i] : '0';
            }*/

            return refined_result;
        }

        public void Calculate()
        {
            foreach(char c in _hex)
                _bin_result += Get4BitBinaryFromInt(ConvertHexCharToInt(c)); // 1 char from hex input = 4-bit binary
        }
    }
}
