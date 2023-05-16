using System;
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
            ICal cal = null;
            // Initiate mode 
            NumType mode_start = GetNumType(type_start);
            NumType mode_end = GetNumType(type_end);

            try
            {
                if (mode_start == NumType.NONE || mode_end == NumType.NONE)
                    SendNotification("No mode is selected.");
                else
                {
                    if (mode_start == NumType.BIN && mode_end == NumType.INT)
                        cal = new BinaryToIntCal(input);

                    if (mode_start == NumType.INT && mode_end == NumType.BIN)
                        cal = new IntToBinaryCal(input);

                    if (mode_start == NumType.INT && mode_end == NumType.HEX)
                        cal = new IntToHexCal(input);

                    if (mode_start == NumType.HEX && mode_end == NumType.INT)
                        cal = new HexToIntCal(input);
                } 
            }
            catch (ArgumentException ex)
            {
                SendNotification(ex.Message);
            }

            return cal;
                
        }

        public static ICal MakeCalculation(string input, int mode)
        {
            ICal cal = null;
                try
                {
                    switch (mode)
                    {
                        case BINARY_INT_MODE:
                            cal = new BinaryToIntCal(input);
                            break;

                        case INT_BINARY_MODE:
                            cal = new IntToBinaryCal(input);
                            break;

                        case INT_HEX_MODE:
                            cal = new IntToHexCal(input);
                            break;

                        case HEX_INT_MODE:
                            cal = new HexToIntCal(input);
                            break;

                        default:
                            SendNotification("No mode is selected.");
                            break;
                    }
                }
                catch (ArgumentException ex) 
                { 
                    SendNotification(ex.Message); 
                }
                

            return cal;
        }

        public static void SendNotification(string notification)
        {
            NotificationTriggered?.Invoke(null, new NotificationTriggeredEventArgs(notification));
        }
    }
}
