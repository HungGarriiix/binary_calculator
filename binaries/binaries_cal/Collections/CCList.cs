using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using binaries_cal.Calculations;
using binaries_cal.Logics;

namespace binaries_cal.Collections
{
    public class CCList : ICalCollection
    {
        private readonly List<ICal> _cals;
        public event EventHandler CollectionChanged;

        public CCList()
        {
            _cals = new List<ICal>();
        }

        public CCList(List<ICal> cals)
        {
            _cals = cals;
        }

        public void AddNewCal(ICal cal)
        {
            if (cal != null)
            {
                _cals.Insert(0, cal);
                OnCollectionChange();
            }
            else
                throw new Exception("");
        }

        public ICal GetCalculation(int index)
        {
            if (_cals[index] != null)
                return _cals[index];
            else
                CalculatorProcessor.SendNotification($"There is no calculation at position {index + 1}.");
            return null;
        }

        public int GetNumberOfCals()
        {
            return _cals.Count;
        }

        public bool IndexIsInRange(int index)
        {
            return index > 0 && index < GetNumberOfCals();
        }

        public ICalIterator GetForwardIterator()
        {
            return new CIListStraight(this);
        }

        public void OnCollectionChange()
        {
            CollectionChanged?.Invoke(null, null);
        }
    }
}
