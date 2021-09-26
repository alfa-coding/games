
namespace Halma.WFormsGUI
{
    partial class frmStart
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.tbxPlayer1 = new System.Windows.Forms.TextBox();
            this.tbxPlayer2 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(355, 21);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(57, 15);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Welcome";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(312, 85);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer1.TabIndex = 1;
            this.lblPlayer1.Text = "Player 1:";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(312, 157);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer2.TabIndex = 2;
            this.lblPlayer2.Text = "Player 2:\r\n";
            // 
            // tbxPlayer1
            // 
            this.tbxPlayer1.Location = new System.Drawing.Point(383, 85);
            this.tbxPlayer1.Name = "tbxPlayer1";
            this.tbxPlayer1.Size = new System.Drawing.Size(100, 23);
            this.tbxPlayer1.TabIndex = 3;
            // 
            // tbxPlayer2
            // 
            this.tbxPlayer2.Location = new System.Drawing.Point(383, 148);
            this.tbxPlayer2.Name = "tbxPlayer2";
            this.tbxPlayer2.Size = new System.Drawing.Size(100, 23);
            this.tbxPlayer2.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(355, 246);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Game\r\n";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(312, 200);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(63, 15);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "Select size:";
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(383, 200);
            this.nudSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(120, 23);
            this.nudSize.TabIndex = 7;
            this.nudSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbxPlayer2);
            this.Controls.Add(this.tbxPlayer1);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmStart";
            this.Text = "frmStart";
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.TextBox tbxPlayer1;
        private System.Windows.Forms.TextBox tbxPlayer2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown nudSize;
    }
}