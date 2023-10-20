using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot_api_dotnet.Logics
{
    public interface ICalIterator
    {
        event EventHandler CurrentCalChanged;
        int No { get; }
        ICal CurrentCal { get; }
        int NoCalculations { get; }
        bool IsHead { get; }
        bool IsTail { get; }
        void NextCalculation();
        void PreviousCalculation();
        void RecentCalculation();
        void LastCalculation();
        void OnCurrentCalChange();
    }
}
