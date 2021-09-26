
namespace Halma.WFormsGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxBoard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectionText = new System.Windows.Forms.Label();
            this.lblSelectionValue = new System.Windows.Forms.Label();
            this.lblStartingPoint = new System.Windows.Forms.Label();
            this.lblStartingPointValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBoard
            // 
            this.pbxBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxBoard.Location = new System.Drawing.Point(317, 75);
            this.pbxBoard.Name = "pbxBoard";
            this.pbxBoard.Size = new System.Drawing.Size(400, 400);
            this.pbxBoard.TabIndex = 0;
            this.pbxBoard.TabStop = false;
            this.pbxBoard.Click += new System.EventHandler(this.pbxBoard_Click);
            this.pbxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxBoard_Paint);
            this.pbxBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxBoard_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // lblSelectionText
            // 
            this.lblSelectionText.AutoSize = true;
            this.lblSelectionText.Location = new System.Drawing.Point(44, 343);
            this.lblSelectionText.Name = "lblSelectionText";
            this.lblSelectionText.Size = new System.Drawing.Size(100, 15);
            this.lblSelectionText.TabIndex = 3;
            this.lblSelectionText.Text = "Selected position:";
            // 
            // lblSelectionValue
            // 
            this.lblSelectionValue.AutoSize = true;
            this.lblSelectionValue.Location = new System.Drawing.Point(44, 382);
            this.lblSelectionValue.Name = "lblSelectionValue";
            this.lblSelectionValue.Size = new System.Drawing.Size(24, 15);
            this.lblSelectionValue.TabIndex = 4;
            this.lblSelectionValue.Text = "X,Y";
            // 
            // lblStartingPoint
            // 
            this.lblStartingPoint.AutoSize = true;
            this.lblStartingPoint.Location = new System.Drawing.Point(44, 264);
            this.lblStartingPoint.Name = "lblStartingPoint";
            this.lblStartingPoint.Size = new System.Drawing.Size(62, 15);
            this.lblStartingPoint.TabIndex = 5;
            this.lblStartingPoint.Text = "Start Point";
            // 
            // lblStartingPointValue
            // 
            this.lblStartingPointValue.AutoSize = true;
            this.lblStartingPointValue.Location = new System.Drawing.Point(41, 291);
            this.lblStartingPointValue.Name = "lblStartingPointValue";
            this.lblStartingPointValue.Size = new System.Drawing.Size(30, 15);
            this.lblStartingPointValue.TabIndex = 6;
            this.lblStartingPointValue.Text = "Xi,Yi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 584);
            this.Controls.Add(this.lblStartingPointValue);
            this.Controls.Add(this.lblStartingPoint);
            this.Controls.Add(this.lblSelectionValue);
            this.Controls.Add(this.lblSelectionText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectionText;
        private System.Windows.Forms.Label lblSelectionValue;
        private System.Windows.Forms.Label lblStartingPoint;
        private System.Windows.Forms.Label lblStartingPointValue;
    }
}

