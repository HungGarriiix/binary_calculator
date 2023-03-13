using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    static class CalculatorProcessor
    {
        // Create constant of mode IDs
        public const int NO_MODE = 0;
        public const int BINARY_INT_MODE = 1;
        public const int INT_BINARY_MODE = 2;
        public const int INT_HEX_MODE = 3;
        public const int HEX_INT_MODE = 4;
        public static event EventHandler<NotificationTriggeredEventArgs> NotificationTriggered;

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
