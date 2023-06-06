using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binaries
{
    public partial class Form1 : Form
    {
        // Instance initialization
        CalculatorMain main;


        public Form1()
        {
            InitializeComponent();
            main = new CalculatorMain("Admin");

            BindingModeSelectionBox();
            SetupHistorySection();

            CalculatorProcessor.NotificationTriggered += DisplayNotification;
            main.MainCal.CurrentCalChanged += UpdateCalculation;

            SetupBinaryNumbericUpDown();
        }

        private bool InputUI_Enabled
        {
            get { return btnCalculate.Enabled; }
            set 
            {
                txbInput.Enabled = value;
                btnCalculate.Enabled = value; 
            }
        }

        private bool BinaryUI_Visible
        {
            get { return nudBinaryLength.Visible; }
            set
            {
                nudBinaryLength.Visible = value;
                lblBinaryLength.Visible = value;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            main.CollectionCal.AddNewCal(CalculatorProcessor.MakeCalculation(txbInput.Text, cmbModeSelection.SelectedIndex));
        }

        // Calculation history section
        private void btnCalHistoryRecently_Click(object sender, EventArgs e)
        {
            main.MainCal.RecentCalculation();
        }

        private void btnCalHistoryNext_Click(object sender, EventArgs e)
        {
            main.MainCal.NextCalculation();
        }

        private void btnCalHistoryPrevious_Click(object sender, EventArgs e)
        {
            main.MainCal.PreviousCalculation();
        }

        private void btnCalHistoryLast_Click(object sender, EventArgs e)
        {
            main.MainCal.LastCalculation();
        }

        // When the mode is selected ...
        private void cmbModeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Default universal settings for all modes
            txbInput.Text = String.Empty;
            txbResult.Text = String.Empty;

            // Settings for each modes
            switch(cmbModeSelection.SelectedIndex)
            {
                case CalculatorProcessor.NO_MODE:

                    lblInput.Text = "Please insert ________:";
                    InputUI_Enabled = false;
                    BinaryUI_Visible = false;
                    break;

                case CalculatorProcessor.BIN_INT_MODE:

                    lblInput.Text = "Please insert a binary chain:";
                    InputUI_Enabled = true;
                    BinaryUI_Visible = false;
                    break;

                case CalculatorProcessor.INT_BIN_MODE:

                    lblInput.Text = "Please insert an integer:";
                    InputUI_Enabled = true;
                    BinaryUI_Visible = true;
                    break;

                case CalculatorProcessor.INT_HEX_MODE:

                    lblInput.Text = "Please insert an integer:";
                    InputUI_Enabled = true;
                    BinaryUI_Visible = false;
                    break;

                case CalculatorProcessor.HEX_INT_MODE:
                    lblInput.Text = "Please insert a hexadecimal:";
                    InputUI_Enabled = true;
                    BinaryUI_Visible = false;
                    break;

                default:
                    // Erase all data on the window
                    break;
            }
        }

        private void UpdateCalculation(object sender, EventArgs e)
        {
            if (main.MainCal.NoCalculations > 0 && main.MainCal.CurrentCal != null)
            {
                // Change calculation main section
                // Change comboBox first because the textboxes will be resetted if SelectedIndex changes
                txbInput.Text = main.MainCal.CurrentCal.Input;
                txbResult.Text = main.MainCal.CurrentCal.Result;

                // Change nud if the result is binary
                if (cmbModeSelection.SelectedIndex == CalculatorProcessor.INT_BIN_MODE)
                {
                    nudBinaryLength.ValueChanged -= AlterBinaryChain;   // Remember to shut down event to prevent nud from triggering in a meanwhile

                    // Change nud value from here to prevent nud from triggering the event continuously
                    nudBinaryLength.Minimum = txbResult.Text.Length;
                    nudBinaryLength.Value = txbResult.Text.Length;
                    // The settings end here. Resubscribe the event to resume the functionality

                    nudBinaryLength.ValueChanged += AlterBinaryChain;
                }

                // Change history selection section
                txbCalHistory.Text = main.MainCal.No.ToString();
                lblCalHistory.Text = $"out of {main.MainCal.NoCalculations}";

                btnCalHistoryRecently.Enabled   = !main.MainCal.IsHead;
                btnCalHistoryNext.Enabled       = !main.MainCal.IsHead;
                btnCalHistoryPrevious.Enabled   = !main.MainCal.IsTail;
                btnCalHistoryLast.Enabled       = !main.MainCal.IsTail;
            }
        }

        private void AlterBinaryChain(object sender, EventArgs e)
        {
            if (main.MainCal.CurrentCal != null && main.MainCal.CurrentCal is IntToBinaryCal)
            {
                txbResult.Text = ((IBinaryExtend)(main.MainCal.CurrentCal)).GetExtendedBinary((int)nudBinaryLength.Value);
            }
        }

        private void SetupBinaryNumbericUpDown()
        {
            // NumbericUpDown initial settings
            nudBinaryLength.Increment = 4;
            nudBinaryLength.Value = 0;
            nudBinaryLength.ValueChanged += AlterBinaryChain;
        }

        private void BindingModeSelectionBox()
        {
            cmbModeSelection.DataSource = main.GetModes();
            // None mode is default
            cmbModeSelection.SelectedIndex = CalculatorProcessor.NO_MODE;
        }

        private void SetupHistorySection()
        {
            txbCalHistory.Text = "_";
            lblCalHistory.Text = $"out of ___";
            txbCalHistory.ReadOnly = true;

            btnCalHistoryRecently.Enabled = false;
            btnCalHistoryNext.Enabled = false;
            btnCalHistoryPrevious.Enabled = false;
            btnCalHistoryLast.Enabled = false;
        }

        private void DisplayNotification(object sender, NotificationTriggeredEventArgs n)
        {
            MessageBox.Show(n.PrintMessage());
        }
    }
}
