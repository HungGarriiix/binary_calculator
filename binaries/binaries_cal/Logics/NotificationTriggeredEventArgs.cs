using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries_cal.Logics
{
    public class NotificationTriggeredEventArgs : EventArgs
    {
        public NotificationTriggeredEventArgs(string message): base()
        {
            Message = message;
        }

        public string Message { get; private set; }

        public string PrintMessage()
        {
            return Message;
        }
    }
}
