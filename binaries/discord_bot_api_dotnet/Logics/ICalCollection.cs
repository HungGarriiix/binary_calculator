using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot_api_dotnet.Logics
{
    public interface ICalCollection
    {
        event EventHandler CollectionChanged;
        ICal GetCalculation(int index);
        void AddNewCal(ICal cal);
        int GetNumberOfCals();
        bool IndexIsInRange(int index);
        void OnCollectionChange();
        ICalIterator GetForwardIterator();
    }
}
