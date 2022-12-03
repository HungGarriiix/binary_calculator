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
        public Form1()
        {
            InitializeComponent();
            BindingModeSelectionBox();
            SetupHistorySection();

            CalculatorMain.NotificationTriggered += DisplayNotification;
            CalculatorMain.CurrentCalChanged += UpdateCalculation;

            SetupBinaryNumbericUpDown();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (CalculatorMain.AddCurrentCal(cmbModeSelection.SelectedIndex, txbInput.Text))
            {
                txbResult.Text = CalculatorMain.CurrentCal.GetDefaultResult();
            }
            else
            {
                txbResult.Text = String.Empty;
            }
        }

        // Calculation history section
        private void btnCalHistoryRecently_Click(object sender, EventArgs e)
        {
            CalculatorMain.RecentCalculation();
        }

        private void btnCalHistoryNext_Click(object sender, EventArgs e)
        {
            CalculatorMain.NextCalculation();
        }

        private void btnCalHistoryPrevious_Click(object sender, EventArgs e)
        {
            CalculatorMain.PreviousCalculation();
        }

        private void btnCalHistoryLast_Click(object sender, EventArgs e)
        {
            CalculatorMain.LastCalculation();
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
                case CalculatorMain.NO_MODE:

                    lblInput.Text = "Please insert ________:";
                    txbInput.Enabled = false;
                    btnCalculate.Enabled = false;
                    lblBinaryLength.Visible = false;
                    nudBinaryLength.Visible = false;

                    break;
                case CalculatorMain.BINARY_CAL_MODE:

                    lblInput.Text = "Please insert a binary chain:";
                    txbInput.Enabled = true;
                    btnCalculate.Enabled = true;
                    lblBinaryLength.Visible = false;
                    nudBinaryLength.Visible = false;

                    break;
                case CalculatorMain.INT_CAL_MODE:

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
            if (CalculatorMain.No != 0)
            {
                // Change calculation main section
                // Change comboBox first because the textboxes will be resetted if SelectedIndex changes
                cmbModeSelection.SelectedIndex = (CalculatorMain.CurrentCal is BinaryToIntCal) ? CalculatorMain.BINARY_CAL_MODE : CalculatorMain.INT_CAL_MODE;
                txbInput.Text = CalculatorMain.CurrentCal.GetInput();
                txbResult.Text = CalculatorMain.CurrentCal.GetDefaultResult();

                // Change nud if the result is binary
                if (cmbModeSelection.SelectedIndex == CalculatorMain.INT_CAL_MODE)
                {
                    nudBinaryLength.ValueChanged -= AlterBinaryChain;

                    // Change nud value from here to prevent nud from triggering the event continuously
                    nudBinaryLength.Minimum = txbResult.Text.Length;
                    nudBinaryLength.Value = txbResult.Text.Length;
                    // The settings end here. Resubscribe the event to resume the functionality

                    nudBinaryLength.ValueChanged += AlterBinaryChain;
                }

                // Change history selection section
                int count = CalculatorMain.GetNumberOfDoneCalculations();
                txbCalHistory.Text = CalculatorMain.No.ToString();
                lblCalHistory.Text = $"out of {count}";


                if (CalculatorMain.No == 1)
                {
                    btnCalHistoryRecently.Visible = false;
                    btnCalHistoryNext.Visible = false;
                    btnCalHistoryPrevious.Visible = true;
                    btnCalHistoryLast.Visible = true;
                }
                else if (CalculatorMain.No == count)
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
            if (CalculatorMain.CurrentCal != null && CalculatorMain.CurrentCal is IntToBinaryCal)
            {
                txbResult.Text = ((IntToBinaryCal)(CalculatorMain.CurrentCal)).GetExtendedBinary((int)nudBinaryLength.Value);
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
            cmbModeSelection.DataSource = CalculatorMain.GetModes();
            // None mode is default
            cmbModeSelection.SelectedIndex = CalculatorMain.NO_MODE;
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
