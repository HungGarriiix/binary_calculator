namespace binaries
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbInput = new System.Windows.Forms.TextBox();
            this.txbResult = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbModeSelection = new System.Windows.Forms.ComboBox();
            this.lblCalculationModeNotif = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.nudBinaryLength = new System.Windows.Forms.NumericUpDown();
            this.lblBinaryLength = new System.Windows.Forms.Label();
            this.lblCalHistory = new System.Windows.Forms.Label();
            this.txbCalHistory = new System.Windows.Forms.TextBox();
            this.btnCalHistoryPrevious = new System.Windows.Forms.Button();
            this.btnCalHistoryNext = new System.Windows.Forms.Button();
            this.btnCalHistoryRecently = new System.Windows.Forms.Button();
            this.btnCalHistoryLast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBinaryLength)).BeginInit();
            this.SuspendLayout();
            // 
            // txbInput
            // 
            this.txbInput.Location = new System.Drawing.Point(55, 46);
            this.txbInput.Name = "txbInput";
            this.txbInput.Size = new System.Drawing.Size(267, 20);
            this.txbInput.TabIndex = 0;
            // 
            // txbResult
            // 
            this.txbResult.Location = new System.Drawing.Point(55, 156);
            this.txbResult.Name = "txbResult";
            this.txbResult.ReadOnly = true;
            this.txbResult.Size = new System.Drawing.Size(267, 20);
            this.txbResult.TabIndex = 1;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(55, 27);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(91, 13);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Please insert ___:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(55, 140);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result";
            // 
            // cmbModeSelection
            // 
            this.cmbModeSelection.FormattingEnabled = true;
            this.cmbModeSelection.Location = new System.Drawing.Point(55, 73);
            this.cmbModeSelection.Name = "cmbModeSelection";
            this.cmbModeSelection.Size = new System.Drawing.Size(121, 21);
            this.cmbModeSelection.TabIndex = 4;
            this.cmbModeSelection.SelectedIndexChanged += new System.EventHandler(this.cmbModeSelection_SelectedIndexChanged);
            // 
            // lblCalculationModeNotif
            // 
            this.lblCalculationModeNotif.AutoSize = true;
            this.lblCalculationModeNotif.Location = new System.Drawing.Point(183, 80);
            this.lblCalculationModeNotif.Name = "lblCalculationModeNotif";
            this.lblCalculationModeNotif.Size = new System.Drawing.Size(281, 13);
            this.lblCalculationModeNotif.TabIndex = 5;
            this.lblCalculationModeNotif.Text = "Please select calculation mode before using the calculator";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(55, 101);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // nudBinaryLength
            // 
            this.nudBinaryLength.Location = new System.Drawing.Point(358, 156);
            this.nudBinaryLength.Name = "nudBinaryLength";
            this.nudBinaryLength.Size = new System.Drawing.Size(106, 20);
            this.nudBinaryLength.TabIndex = 8;
            // 
            // lblBinaryLength
            // 
            this.lblBinaryLength.AutoSize = true;
            this.lblBinaryLength.Location = new System.Drawing.Point(355, 140);
            this.lblBinaryLength.Name = "lblBinaryLength";
            this.lblBinaryLength.Size = new System.Drawing.Size(126, 13);
            this.lblBinaryLength.TabIndex = 9;
            this.lblBinaryLength.Text = "Adjust binary length here:";
            // 
            // lblCalHistory
            // 
            this.lblCalHistory.AutoSize = true;
            this.lblCalHistory.Location = new System.Drawing.Point(437, 46);
            this.lblCalHistory.Name = "lblCalHistory";
            this.lblCalHistory.Size = new System.Drawing.Size(55, 13);
            this.lblCalHistory.TabIndex = 10;
            this.lblCalHistory.Text = "out of ___";
            // 
            // txbCalHistory
            // 
            this.txbCalHistory.Location = new System.Drawing.Point(397, 43);
            this.txbCalHistory.Name = "txbCalHistory";
            this.txbCalHistory.Size = new System.Drawing.Size(34, 20);
            this.txbCalHistory.TabIndex = 11;
            // 
            // btnCalHistoryPrevious
            // 
            this.btnCalHistoryPrevious.Location = new System.Drawing.Point(498, 41);
            this.btnCalHistoryPrevious.Name = "btnCalHistoryPrevious";
            this.btnCalHistoryPrevious.Size = new System.Drawing.Size(23, 23);
            this.btnCalHistoryPrevious.TabIndex = 12;
            this.btnCalHistoryPrevious.Text = ">";
            this.btnCalHistoryPrevious.UseVisualStyleBackColor = true;
            this.btnCalHistoryPrevious.Click += new System.EventHandler(this.btnCalHistoryPrevious_Click);
            // 
            // btnCalHistoryNext
            // 
            this.btnCalHistoryNext.Location = new System.Drawing.Point(365, 41);
            this.btnCalHistoryNext.Name = "btnCalHistoryNext";
            this.btnCalHistoryNext.Size = new System.Drawing.Size(23, 23);
            this.btnCalHistoryNext.TabIndex = 13;
            this.btnCalHistoryNext.Text = "<";
            this.btnCalHistoryNext.UseVisualStyleBackColor = true;
            this.btnCalHistoryNext.Click += new System.EventHandler(this.btnCalHistoryNext_Click);
            // 
            // btnCalHistoryRecently
            // 
            this.btnCalHistoryRecently.Location = new System.Drawing.Point(329, 41);
            this.btnCalHistoryRecently.Name = "btnCalHistoryRecently";
            this.btnCalHistoryRecently.Size = new System.Drawing.Size(32, 23);
            this.btnCalHistoryRecently.TabIndex = 14;
            this.btnCalHistoryRecently.Text = "<<";
            this.btnCalHistoryRecently.UseVisualStyleBackColor = true;
            this.btnCalHistoryRecently.Click += new System.EventHandler(this.btnCalHistoryRecently_Click);
            // 
            // btnCalHistoryLast
            // 
            this.btnCalHistoryLast.Location = new System.Drawing.Point(527, 40);
            this.btnCalHistoryLast.Name = "btnCalHistoryLast";
            this.btnCalHistoryLast.Size = new System.Drawing.Size(32, 23);
            this.btnCalHistoryLast.TabIndex = 15;
            this.btnCalHistoryLast.Text = ">>";
            this.btnCalHistoryLast.UseVisualStyleBackColor = true;
            this.btnCalHistoryLast.Click += new System.EventHandler(this.btnCalHistoryLast_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 205);
            this.Controls.Add(this.btnCalHistoryLast);
            this.Controls.Add(this.btnCalHistoryRecently);
            this.Controls.Add(this.btnCalHistoryNext);
            this.Controls.Add(this.btnCalHistoryPrevious);
            this.Controls.Add(this.txbCalHistory);
            this.Controls.Add(this.lblCalHistory);
            this.Controls.Add(this.lblBinaryLength);
            this.Controls.Add(this.nudBinaryLength);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblCalculationModeNotif);
            this.Controls.Add(this.cmbModeSelection);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txbResult);
            this.Controls.Add(this.txbInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudBinaryLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbInput;
        private System.Windows.Forms.TextBox txbResult;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbModeSelection;
        private System.Windows.Forms.Label lblCalculationModeNotif;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.NumericUpDown nudBinaryLength;
        private System.Windows.Forms.Label lblBinaryLength;
        private System.Windows.Forms.Label lblCalHistory;
        private System.Windows.Forms.TextBox txbCalHistory;
        private System.Windows.Forms.Button btnCalHistoryPrevious;
        private System.Windows.Forms.Button btnCalHistoryNext;
        private System.Windows.Forms.Button btnCalHistoryRecently;
        private System.Windows.Forms.Button btnCalHistoryLast;
    }
}

