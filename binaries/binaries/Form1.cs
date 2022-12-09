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
            main = new CalculatorMain();

            BindingModeSelectionBox();
            SetupHistorySection();

            CalculatorProcessor.NotificationTriggered += DisplayNotification;
            main.Cal.CurrentCalChanged += UpdateCalculation;

            SetupBinaryNumbericUpDown();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (main.Cal.AddNewCal(CalculatorProcessor.MakeCalculation(txbInput.Text, cmbModeSelection.SelectedIndex)))
            {
                txbResult.Text = main.Cal.CurrentCal.Result;
            }
            else
            {
                txbResult.Text = String.Empty;
            }
        }

        // Calculation history section
        private void btnCalHistoryRecently_Click(object sender, EventArgs e)
        {
            main.Cal.RecentCalculation();
        }

        private void btnCalHistoryNext_Click(object sender, EventArgs e)
        {
            main.Cal.NextCalculation();
        }

        private void btnCalHistoryPrevious_Click(object sender, EventArgs e)
        {
            main.Cal.PreviousCalculation();
        }

        private void btnCalHistoryLast_Click(object sender, EventArgs e)
        {
            main.Cal.LastCalculation();
        }

        // When the mode is selected ...
        private void cmbModeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Default universal settings for all modes
            txbInput.Text = String.Empty;
            txbResult.Text = String.Empty;
/*            CalculatorMain.RecentCalculation();*/

            // Settings for each modes
            int index = cmbModeSelection.SelectedIndex;
            switch(index)
            {
                case CalculatorProcessor.NO_MODE:

                    lblInput.Text = "Please insert ________:";
                    txbInput.Enabled = false;
                    btnCalculate.Enabled = false;
                    lblBinaryLength.Visible = false;
                    nudBinaryLength.Visible = false;

                    break;
                case CalculatorProcessor.BINARY_INT_MODE:

                    lblInput.Text = "Please insert a binary chain:";
                    txbInput.Enabled = true;
                    btnCalculate.Enabled = true;
                    lblBinaryLength.Visible = false;
                    nudBinaryLength.Visible = false;

                    break;
                case CalculatorProcessor.INT_BINARY_MODE:

                    lblInput.Text = "Please insert an integer:";
                    txbInput.Enabled = true;
                    btnCalculate.Enabled = true;
                    lblBinaryLength.Visible = true;
                    nudBinaryLength.Visible = true;

                    break;
                default:
                    // Erase all data on the window
                    break;
            }
        }

        private void UpdateCalculation(object sender, EventArgs e)
        {
            if (main.Cal.No != 0)
            {
                // Change calculation main section
                // Change comboBox first because the textboxes will be resetted if SelectedIndex changes
                cmbModeSelection.SelectedIndex = (main.Cal.CurrentCal is BinaryToIntCal) ? CalculatorProcessor.BINARY_INT_MODE : CalculatorProcessor.INT_BINARY_MODE;
                txbInput.Text = main.Cal.CurrentCal.Input;
                txbResult.Text = main.Cal.CurrentCal.Result;

                // Change nud if the result is binary
                if (cmbModeSelection.SelectedIndex == CalculatorProcessor.INT_BINARY_MODE)
                {
                    nudBinaryLength.ValueChanged -= AlterBinaryChain;

                    // Change nud value from here to prevent nud from triggering the event continuously
                    nudBinaryLength.Minimum = txbResult.Text.Length;
                    nudBinaryLength.Value = txbResult.Text.Length;
                    // The settings end here. Resubscribe the event to resume the functionality

                    nudBinaryLength.ValueChanged += AlterBinaryChain;
                }

                // Change history selection section
                txbCalHistory.Text = main.Cal.No.ToString();
                lblCalHistory.Text = $"out of {main.Cal.NoCalculations}";


                if (main.Cal.No == 1)
                {
                    btnCalHistoryRecently.Visible = false;
                    btnCalHistoryNext.Visible = false;
                    btnCalHistoryPrevious.Visible = true;
                    btnCalHistoryLast.Visible = true;
                }
                else if (main.Cal.No == main.Cal.NoCalculations)
                {
                    btnCalHistoryRecently.Visible = true;
                    btnCalHistoryNext.Visible = true;
                    btnCalHistoryPrevious.Visible = false;
                    btnCalHistoryLast.Visible = false;
                }
                else
                {
                    btnCalHistoryRecently.Visible = true;
                    btnCalHistoryNext.Visible = true;
                    btnCalHistoryPrevious.Visible = true;
                    btnCalHistoryLast.Visible = true;
                }

            }
        }

        private void AlterBinaryChain(object sender, EventArgs e)
        {
            if (main.Cal.CurrentCal != null && main.Cal.CurrentCal is IntToBinaryCal)
            {
                txbResult.Text = ((IBinaryExtend)(main.Cal.CurrentCal)).GetExtendedBinary((int)nudBinaryLength.Value);
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

            btnCalHistoryRecently.Visible = false;
            btnCalHistoryNext.Visible = false;
            btnCalHistoryPrevious.Visible = false;
            btnCalHistoryLast.Visible = false;
            
        }

        private void DisplayNotification(object sender, string notification)
        {
            MessageBox.Show(notification);
        }
    }
}
