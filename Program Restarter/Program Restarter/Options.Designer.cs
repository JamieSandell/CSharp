namespace Program_Restarter
{
    partial class Options
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
            this.Save = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalInMilliSeconds = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelProgramToRestart = new System.Windows.Forms.Label();
            this.textBoxProgramToRestart = new System.Windows.Forms.TextBox();
            this.buttonSelectProgram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 126);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(330, 126);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Location = new System.Drawing.Point(133, 17);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownInterval.TabIndex = 2;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // labelIntervalInMilliSeconds
            // 
            this.labelIntervalInMilliSeconds.AutoSize = true;
            this.labelIntervalInMilliSeconds.Location = new System.Drawing.Point(9, 19);
            this.labelIntervalInMilliSeconds.Name = "labelIntervalInMilliSeconds";
            this.labelIntervalInMilliSeconds.Size = new System.Drawing.Size(118, 13);
            this.labelIntervalInMilliSeconds.TabIndex = 3;
            this.labelIntervalInMilliSeconds.Text = "Interval in milli-seconds:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelProgramToRestart
            // 
            this.labelProgramToRestart.AutoSize = true;
            this.labelProgramToRestart.Location = new System.Drawing.Point(9, 53);
            this.labelProgramToRestart.Name = "labelProgramToRestart";
            this.labelProgramToRestart.Size = new System.Drawing.Size(93, 13);
            this.labelProgramToRestart.TabIndex = 4;
            this.labelProgramToRestart.Text = "Program to restart:";
            // 
            // textBoxProgramToRestart
            // 
            this.textBoxProgramToRestart.Location = new System.Drawing.Point(133, 53);
            this.textBoxProgramToRestart.Name = "textBoxProgramToRestart";
            this.textBoxProgramToRestart.Size = new System.Drawing.Size(190, 20);
            this.textBoxProgramToRestart.TabIndex = 5;
            // 
            // buttonSelectProgram
            // 
            this.buttonSelectProgram.Location = new System.Drawing.Point(330, 49);
            this.buttonSelectProgram.Name = "buttonSelectProgram";
            this.buttonSelectProgram.Size = new System.Drawing.Size(75, 36);
            this.buttonSelectProgram.TabIndex = 6;
            this.buttonSelectProgram.Text = "Select Program";
            this.buttonSelectProgram.UseVisualStyleBackColor = true;
            this.buttonSelectProgram.Click += new System.EventHandler(this.buttonSelectProgram_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 161);
            this.Controls.Add(this.buttonSelectProgram);
            this.Controls.Add(this.textBoxProgramToRestart);
            this.Controls.Add(this.labelProgramToRestart);
            this.Controls.Add(this.labelIntervalInMilliSeconds);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelIntervalInMilliSeconds;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelProgramToRestart;
        private System.Windows.Forms.TextBox textBoxProgramToRestart;
        private System.Windows.Forms.Button buttonSelectProgram;
    }
}