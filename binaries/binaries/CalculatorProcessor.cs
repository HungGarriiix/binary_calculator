﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public static class CalculatorProcessor
    {
        // Create constant of mode IDs
        public const int NO_MODE = 0;
        public const int BINARY_INT_MODE = 1;
        public const int INT_BINARY_MODE = 2;
        public const int INT_HEX_MODE = 3;
        public const int HEX_INT_MODE = 4;
        public static event EventHandler<NotificationTriggeredEventArgs> NotificationTriggered;

        public enum NumType { NONE, INT, BIN, HEX }

        private static NumType GetNumType(string mode)
        {
            switch(mode)
            {
                case "int": case "integer":
                    return NumType.INT;

                case "bin": case "binary":
                    return NumType.BIN;

                case "hex": case "hexadecimal":
                    return NumType.HEX;

                default:
                    return NumType.NONE;
            }
        }

        public static ICal MakeCalculation(string input, string type_start, string type_end)
        {
            // Initiate mode 
            NumType mode_start = GetNumType(type_start);
            NumType mode_end = GetNumType(type_end);

            try
            {
                // Checking function parameters
                if (mode_start == NumType.NONE || mode_end == NumType.NONE)
                    throw new ArgumentException("One of the mode input is incorrect.");
                if (mode_start == mode_end)
                    throw new ArgumentException("Cannot convert input to the same type as the initial.");

                // Main calculator execution
                if (mode_start == NumType.BIN && mode_end == NumType.INT)
                    return new BinaryToIntCal(input);
                if (mode_start == NumType.INT && mode_end == NumType.BIN)
                    return new IntToBinaryCal(input);
                if (mode_start == NumType.INT && mode_end == NumType.HEX)
                    return new IntToHexCal(input);
                if (mode_start == NumType.HEX && mode_end == NumType.INT)
                    return new HexToIntCal(input);
            }
            catch (ArgumentException ex)
            {
                SendNotification(ex.Message);
            }

            return null;
                
        }

        public static ICal MakeCalculation(string input, int mode)
        {
            try
            {
                switch (mode)
                {
                    case BINARY_INT_MODE:
                        return new BinaryToIntCal(input);

                    case INT_BINARY_MODE:
                        return new IntToBinaryCal(input);

                    case INT_HEX_MODE:
                        return new IntToHexCal(input);

                    case HEX_INT_MODE:
                        return new HexToIntCal(input);

                    default:
                        throw new ArgumentException("No mode is selected.");
                }
            }
            catch (ArgumentException ex) 
            { 
                SendNotification(ex.Message); 
            }
            return null;
        }

        public static void SendNotification(string notification)
        {
            NotificationTriggered?.Invoke(null, new NotificationTriggeredEventArgs(notification));
        }
    }
}
