using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaries
{
    public static class CalculatorMain
    {
        // Create constant of mode IDs
        public const int NO_MODE = 0;
        public const int BINARY_CAL_MODE = 1;
        public const int INT_CAL_MODE = 2;

        // Normal initialization
        private static readonly List<string> mode_names = new List<string>();
        private static List<ICal> calculations;
        private static int no;
        private static ICal currentCal;
        public static event EventHandler<string> NotificationTriggered;
        // Due to static class cannot implement interfaces, PropertyChanged should be created manually
        public static event EventHandler CurrentCalChanged;

        static CalculatorMain()
        {
            AddModeNames();
            InitializeIndex();
        }

        public static int No
        {
            get { return no; }

            private set
            {
                no = value;
                CurrentCal = GetCalculationByIndex(no);
            }
        }

        public static ICal CurrentCal 
        { 
            get { return currentCal; } 
            
            private set
            {
                currentCal = value;
                OnCurrentCalChange();
            }
        }

        private static void AddModeNames()
        {
            mode_names.Add("<none>");
            mode_names.Add("Binary -> Integer");
            mode_names.Add("Integer -> Binary");
        }

        private static void InitializeIndex()
        {
            calculations = new List<ICal>();
            No = 0;
        }

        public static int GetNumberOfDoneCalculations()
        {
            return calculations.Count;
        }

        public static string[] GetModes()
        {
            return mode_names.ToArray();
        }

        private static ICal GetCalculationByIndex(int index)
        {
            // There might be a shorter version using LINQ
            if (index > 0)
                return calculations[calculations.Count - index];
            else
                return null;
        }

        public static void NextCalculation()
        {
            if (No != 1)
                No--;
        }

        public static void PreviousCalculation()
        {
            if (No != calculations.Count)
                No++;
        }

        public static void RecentCalculation()
        {
            No = 1;
        }

        public static void LastCalculation()
        {
            No = GetNumberOfDoneCalculations();
        }

        private static BinaryCal CalculateBinaryToInt(string given_binary)
        {
            BinaryCal cal = new BinaryCal(given_binary);
            return cal;
        }

        private static IntCal CalculateIntToBinary(int given_int)
        {
            IntCal cal = new IntCal(given_int);
            return cal;
        }

        private static ICal StartCalculation(int mode, string input)
        {
            switch (mode)
            {
                case BINARY_CAL_MODE:
                    // Validate if the input is binary
                    // Original version
                    bool isBinary = true;
                    foreach(char c in input)
                    {
                        if (c != '0' && c != '1')
                        {
                            isBinary = false;
                        }
                    }

                    // LINX version

                    if (isBinary)
                    {
                        return CalculateBinaryToInt(input);
                    }
                    else
                    {
                        SendNotification("The input is not a binary chain.");
                        return null;
                    }
                case INT_CAL_MODE:
                    // TryParse returns bool value whenever the given "integer" is convertible
                    // It also returns converted integer if the convertion is done
                    if (int.TryParse(input, out int input_int))
                    {
                        return CalculateIntToBinary(input_int);
                    }
                    else
                    {
                        SendNotification("The input is not an integer.");
                        return null;
                    }
                default:
                    SendNotification("No mode is selected.");
                    return null;
            }
        }

        public static bool AddCurrentCal(int mode, string input)
        {
            ICal cal = StartCalculation(mode, input);
            if (cal != null)
            {
                calculations.Add(cal);
                RecentCalculation();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SendNotification(string notification)
        {
            NotificationTriggered?.Invoke(null, notification);
        }

        public static void OnCurrentCalChange()
        {
            CurrentCalChanged?.Invoke(null, null);
        }
    }
}
