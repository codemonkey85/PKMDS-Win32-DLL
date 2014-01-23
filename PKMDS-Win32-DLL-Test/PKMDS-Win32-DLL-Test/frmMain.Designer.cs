namespace PKMDS_Win32_DLL_Test
{
    partial class frmMain
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
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.numSpecies = new System.Windows.Forms.NumericUpDown();
            this.cbBox = new System.Windows.Forms.ComboBox();
            this.numSlot = new System.Windows.Forms.NumericUpDown();
            this.btnTest2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(12, 38);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(38, 13);
            this.lblTest.TabIndex = 1;
            this.lblTest.Text = "lblTest";
            // 
            // numSpecies
            // 
            this.numSpecies.Location = new System.Drawing.Point(93, 15);
            this.numSpecies.Maximum = new decimal(new int[] {
            649,
            0,
            0,
            0});
            this.numSpecies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpecies.Name = "numSpecies";
            this.numSpecies.Size = new System.Drawing.Size(66, 20);
            this.numSpecies.TabIndex = 2;
            this.numSpecies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbBox
            // 
            this.cbBox.FormattingEnabled = true;
            this.cbBox.Location = new System.Drawing.Point(12, 54);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(121, 21);
            this.cbBox.TabIndex = 3;
            // 
            // numSlot
            // 
            this.numSlot.Location = new System.Drawing.Point(139, 55);
            this.numSlot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSlot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSlot.Name = "numSlot";
            this.numSlot.Size = new System.Drawing.Size(49, 20);
            this.numSlot.TabIndex = 4;
            this.numSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(12, 81);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(75, 23);
            this.btnTest2.TabIndex = 5;
            this.btnTest2.Text = "Test 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.numSlot);
            this.Controls.Add(this.cbBox);
            this.Controls.Add(this.numSpecies);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnTest);
            this.Name = "frmMain";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.numSpecies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.NumericUpDown numSpecies;
        private System.Windows.Forms.ComboBox cbBox;
        private System.Windows.Forms.NumericUpDown numSlot;
        private System.Windows.Forms.Button btnTest2;
    }
}

