using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class BinaryToIntCal : ICal
    {
        private readonly string _binary;
        private int _int_result;

        public BinaryToIntCal(string input)
        {
            if(CheckInput(input))
            {
                _binary = input;
                _int_result = 0;
                Calculate();
            }
        }

        public string Input { get { return _binary; } }
        public string Result { get { return _int_result.ToString(); } }

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

/*        private int GetBinaryPower(int power)
        {
            int powered = 1;
            for (int i = 0; i < power; i++)
            {
                powered *= 2;
            }
            return powered;
        }*/

        public void Calculate()
        {
            // Version 1:
            /*for (int i = 0; i < _binary.Length; i++)
            {
                _int_result += GetBinaryInt(_binary[i]) * GetBinaryPower(_binary.Length - i - 1);
            }*/

            // Version 2:
            int power = 1;
            for (int i = _binary.Length - 1; i > -1; i--)
            {
                _int_result += GetBinaryInt(_binary[i]) * power;
                power *= 2;
            }
        }
    }
}
