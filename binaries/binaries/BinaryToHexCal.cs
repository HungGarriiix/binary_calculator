using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace binaries
{
    public class BinaryToHexCal : ICal, IBinaryExtend
    {
        private readonly string _bin;
        private string _hex_result;

        public BinaryToHexCal(string input)
        {
            if (CheckInput(input))
            {
                _bin = input;
                _bin = GetExtendedBinary(input.Length);
                _hex_result = string.Empty;

                Calculate();
            }
        }

        public string ModeTitle { get { return "Binary\u2082 => Hexadecimal\u2081\u2086:"; } }
        public string Input { get { return _bin; } }
        public string Result { get { return _hex_result; } }
        public string ResultFull { get { return $"{Input} => {Result}."; } }

        public bool CheckInput(string input)
        {
            if (input == string.Empty)
                throw new ArgumentException("The input is empty.");

            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                {
                    //return false;
                    throw new ArgumentException("The input is not a binary chain.");
                }
            }

            return true;
        }

        private int GetBinaryInt(char i)
        {
            return (i == '0') ? 0 : 1;
        }

        private char ConvertBinToHexChar(string b)
        {
            if (b.Length > 4)
                throw new ArgumentException("The input is not in a 4-bit binary set.");

            // Convert binary to integer
            int i = 0;
            int bas = 1;
            for(int z = 3; z >= 0; z--)
            {
                i += GetBinaryInt(b[z]) * bas;
                bas *= 2;
            }

            // Set of hex chars (Exp: A - 10, B - 11, ..., F - 15)
            char[] hex = { 'A', 'B', 'C', 'D', 'E', 'F' };

            if (i >= 0 && i < 10)
                return Convert.ToChar(i + 48);  // Convert the ints to Unicode characters
            if (i >= 10 && i < 16)
                return hex[i - 10];     // Fit the integer to the index of hex chars array

            return ' ';
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
            int added_length = GetBinaryChainLength(_bin, length) - _bin.Length;
            for (int i = 0; i < added_length; i++)
            {
                refined_result += "0";
            }
            refined_result += _bin;

            // Version 2
            /*for (int i = GetBinaryChainLength(_binary_result, length) - 1; i > 0; i--)
            {
                refined_result += (i <= _binary_result.Length - 1) ? _binary_result[i] : '0';
            }*/

            return refined_result;
        }

        public void Calculate()
        {
            // Calculation prep
            Queue<string> bin_4_bits = new Queue<string>();

            // Separate the input into 4-bit binary strings
            string tracer = string.Empty;
            for (int i = 0; i < _bin.Length; i++)
            {
                tracer += _bin[i];
                if (i%4 == 3)   // Cuts the binary string if the length reaches to 4
                {
                    bin_4_bits.Enqueue(tracer);
                    tracer = string.Empty;
                }
            }

            while(bin_4_bits.Count > 0)
                _hex_result += ConvertBinToHexChar(bin_4_bits.Dequeue());
        }
    }
}
