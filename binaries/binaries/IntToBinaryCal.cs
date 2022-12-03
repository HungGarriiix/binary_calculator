using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class IntToBinaryCal : ICal, IBinaryExtend
    {
        public IntToBinaryCal(int integer)
        {
            Integer = integer;
            Result = "";
            Calculate();
        }

        public int Integer { get; private set; }
        public string Result { get; private set; }

        public void Calculate()
        {
            // Version 1:
            // Get a stack of numbers powered by 2 from 0 to Integer
            int power_base = 1;
            Stack<int> power_stack = new Stack<int>();
            while (power_base <= Integer)
            {
                power_stack.Push(power_base);
                power_base *= 2;
            }

            // Go through each element and sum all of them
            // If the sum is still lower than Integer, include it in sum and add "1" to binary
            // Otherwise include none and add "0" to binary
            int total = 0;
            while (power_stack.Count > 0)
            {
                int pop = power_stack.Pop();
                if (total + pop <= Integer)
                {
                    total += pop;
                    Result += "1";
                }
                else
                {
                    Result += "0";
                }
            }
        }

        public string GetExtendedBinary(int length)
        {
            // If requested length < result length
            // Get result with min length
            // Otherwise get result with required length
            string refined_result = "";
            int min_length = 0;
            if (length < Result.Length)
            {
                while (min_length < Result.Length)
                {
                    min_length += 4;
                }
            }
            else
            {
                if (length % 4 == 0)
                {
                    min_length = length;
                }
                else
                {
                    while (min_length < length)
                    {
                        min_length += 4;
                    }
                }
            }
            
            int added_length = min_length - Result.Length;
            for (int i = 0; i < added_length; i++)
            {
                refined_result += "0";
            }
            refined_result += Result;
            return refined_result;
        }

        public string GetInput()
        {
            return Integer.ToString();
        }

        public string GetDefaultResult()
        {
            return GetExtendedBinary(1);
        }
    }
}
