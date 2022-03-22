
namespace AutoGif_windows
{
    partial class main_window
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
            this.button1 = new System.Windows.Forms.Button();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.delayConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 67);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start Recording";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(243, 48);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(125, 27);
            this.delayTextBox.TabIndex = 2;
            this.delayTextBox.TextChanged += new System.EventHandler(this.delayTextBox_TextChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(243, 25);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(47, 20);
            this.delayLabel.TabIndex = 3;
            this.delayLabel.Text = "Delay";
            // 
            // delayConfirmButton
            // 
            this.delayConfirmButton.Location = new System.Drawing.Point(374, 48);
            this.delayConfirmButton.Name = "delayConfirmButton";
            this.delayConfirmButton.Size = new System.Drawing.Size(94, 29);
            this.delayConfirmButton.TabIndex = 4;
            this.delayConfirmButton.Text = "Confirm";
            this.delayConfirmButton.UseVisualStyleBackColor = true;
            this.delayConfirmButton.Click += new System.EventHandler(this.delayConfirmButton_Click);
            // 
            // main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 213);
            this.Controls.Add(this.delayConfirmButton);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "main_window";
            this.Text = "AutoGIF";
            this.Load += new System.EventHandler(this.main_window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Button delayConfirmButton;
    }
}
