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
