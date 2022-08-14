namespace HexMap
{
    partial class MapGenerator
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
            this.PictureBoxPanel = new System.Windows.Forms.Panel();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.ConsoleOutput = new System.Windows.Forms.TextBox();
            this.ConsoleInput = new System.Windows.Forms.TextBox();
            this.PictureBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxPanel
            // 
            this.PictureBoxPanel.AutoScroll = true;
            this.PictureBoxPanel.BackColor = System.Drawing.Color.White;
            this.PictureBoxPanel.Controls.Add(this.PictureBox);
            this.PictureBoxPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.PictureBoxPanel.Location = new System.Drawing.Point(12, 12);
            this.PictureBoxPanel.Name = "PictureBoxPanel";
            this.PictureBoxPanel.Size = new System.Drawing.Size(510, 510);
            this.PictureBoxPanel.TabIndex = 0;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleOutput.Location = new System.Drawing.Point(528, 12);
            this.ConsoleOutput.Multiline = true;
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.ReadOnly = true;
            this.ConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleOutput.Size = new System.Drawing.Size(442, 477);
            this.ConsoleOutput.TabIndex = 1;
            // 
            // ConsoleInput
            // 
            this.ConsoleInput.Location = new System.Drawing.Point(528, 495);
            this.ConsoleInput.Name = "ConsoleInput";
            this.ConsoleInput.Size = new System.Drawing.Size(442, 27);
            this.ConsoleInput.TabIndex = 2;
            // 
            // MapGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 534);
            this.Controls.Add(this.ConsoleInput);
            this.Controls.Add(this.ConsoleOutput);
            this.Controls.Add(this.PictureBoxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MapGenerator";
            this.Text = "Map6";
            this.PictureBoxPanel.ResumeLayout(false);
            this.PictureBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel PictureBoxPanel;
        private PictureBox PictureBox;
        private TextBox ConsoleOutput;
        private TextBox ConsoleInput;
    }
}