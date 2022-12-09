using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class IntToBinaryCal : ICal, IBinaryExtend
    {
        private readonly int _int;
        private string _binary_result;

        public IntToBinaryCal(string input)
        {
            CheckInput(input);

            _int = Convert.ToInt32(input);
            _binary_result = string.Empty;
            Calculate();
        }

        public string Input { get { return _int.ToString(); } }
        public string Result { get { return GetDefaultResult(); } }

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

        private Stack<int> GetPoweredBy2(int input)
        {
            // Version 1:
            // Get a stack of numbers powered by 2 from 0 to Integer
            int power_base = 1;
            Stack<int> power_stack = new Stack<int>();
            while (power_base <= input)
            {
                power_stack.Push(power_base);
                power_base *= 2;
            }
            return power_stack;
        }

        public void Calculate()
        {
            // Go through each element and sum all of them
            // If the sum is still lower than Integer, include it in sum and add "1" to binary
            // Otherwise include none and add "0" to binary
            int total = 0;
            Stack<int> power_stack = GetPoweredBy2(_int);
            while (power_stack.Count > 0)
            {
                int pop = power_stack.Pop();
                if (total + pop <= _int)
                {
                    total += pop;
                    _binary_result += "1";
                }
                else
                {
                    _binary_result += "0";
                }
            }
        }

        private int GetBinaryChainLength(string input, int required_length)
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
            int added_length = GetBinaryChainLength(_binary_result, length) - _binary_result.Length;
            for (int i = 0; i < added_length; i++)
            {
                refined_result += "0";
            }
            refined_result += _binary_result;

            // Version 2
            /*for (int i = GetBinaryChainLength(_binary_result, length) - 1; i > 0; i--)
            {
                refined_result += (i <= _binary_result.Length - 1) ? _binary_result[i] : '0';
            }*/

            return refined_result;
        }

        public string GetDefaultResult()
        {
            return GetExtendedBinary(_binary_result.Length);
        }
    }
}
