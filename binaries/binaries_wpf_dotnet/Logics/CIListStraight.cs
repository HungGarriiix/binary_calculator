using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries_wpf_dotnet.Logics
{
    public class CIListStraight : ICalIterator
    {
        private readonly CCList _collection;
        private int _index;
        private ICal _currentCal;
        public event EventHandler CurrentCalChanged;

        public CIListStraight(CCList cals)
        {
            _collection = cals;
            if (cals.GetNumberOfCals() != 0) No = 1;
        }

        public int No 
        { 
            get { return _index; }
            private set
            {
                _index = value;
                CurrentCal = _collection.GetCalculation(_index - 1);
            }
        }

        public ICal CurrentCal 
        { 
            get { return _currentCal; }
            private set
            {
                _currentCal = value;
                OnCurrentCalChange();
            }
        }

        public int NoCalculations { get { return _collection.GetNumberOfCals(); } }
        public bool IsHead { get { return No == 1; } }
        public bool IsTail { get { return No == NoCalculations; } }

        public void NextCalculation()
        {
            if (!IsHead)
                No--;
        }

        public void PreviousCalculation()
        {
            if (!IsTail)
                No++;
        }

        public void RecentCalculation()
        {
            No = 1;
        }

        public void LastCalculation()
        {
            No = NoCalculations;
        }

        public void OnCurrentCalChange()
        {
            CurrentCalChanged?.Invoke(null, null);
        }
    }
}
