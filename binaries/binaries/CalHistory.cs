using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public class CalHistory
    {
        private List<ICal> calculations;
        private int no;
        private ICal currentCal;
        public EventHandler CurrentCalChanged;

        public CalHistory()
        {
            InitializeIndex();
        }

        public int No 
        { 
            get { return no; }
            private set
            {
                no = value;
                CurrentCal = GetCalculation(no);
            }
        }

        public ICal CurrentCal 
        { 
            get { return currentCal; }
            private set
            {
                currentCal = value;
                OnCurrentCalChanged();
            }
        }
        public int NoCalculations { get { return calculations.Count; } }

        private void InitializeIndex()
        {
            calculations = new List<ICal>();
            No = 0;
        }

        public void NextCalculation()
        {
            if (No != 1)
                No--;
        }

        public void PreviousCalculation()
        {
            if (No != calculations.Count)
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

        public void AddNewCal(ICal cal)
        {

        }

        private ICal GetCalculation(int index)
        {
            // There might be a shorter version using LINQ
            if (index > 0)
                return calculations[calculations.Count - index];
            else
                return null;
        }

        public void OnCurrentCalChanged()
        {
            CurrentCalChanged?.Invoke(null, null);
        }
    }
}
