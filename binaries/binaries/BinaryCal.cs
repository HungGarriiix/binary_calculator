using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class BinaryCal : ICal
    {
        public BinaryCal(string binary)
        {
            Binary = binary;
            Result = -1;

            // There might be an input check to make sure the input is indeed a binary string
            Calculate();
        }

        public string Binary { get; private set; }
        public int Result { get; private set; }

        private int GetBinaryInt(char i)
        {
            if (i == '0')
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int GetBinaryPower(int power)
        {
            int powered = 1;
            for (int i = 0; i < power; i++)
            {
                powered *= 2;
            }
            return powered;
        }

        public void Calculate()
        {
            int result = 0;
            for (int i = 0; i < Binary.Length; i++)
            {
                result += GetBinaryInt(Binary[i]) * GetBinaryPower(Binary.Length - i - 1);
            }
            Result = result;
        }

        public string GetInput()
        {
            return Binary;
        }

        public string GetDefaultResult()
        {
            return Result.ToString();
        }
    }
}
