namespace Binder
{
    partial class TextMessageBox
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
            this.AcceptB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptB
            // 
            this.AcceptB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptB.Location = new System.Drawing.Point(10, 95);
            this.AcceptB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AcceptB.Name = "AcceptB";
            this.AcceptB.Size = new System.Drawing.Size(82, 22);
            this.AcceptB.TabIndex = 1;
            this.AcceptB.Text = "OK";
            this.AcceptB.UseVisualStyleBackColor = true;
            // 
            // CancelB
            // 
            this.CancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelB.Location = new System.Drawing.Point(368, 95);
            this.CancelB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(82, 22);
            this.CancelB.TabIndex = 2;
            this.CancelB.Text = "Cancel";
            this.CancelB.UseVisualStyleBackColor = true;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(11, 10);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(56, 15);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "InfoLabel";
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(11, 27);
            this.Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(440, 23);
            this.Input.TabIndex = 0;
            // 
            // TextMessageBox
            // 
            this.AcceptButton = this.AcceptB;
            this.AccessibleDescription = "Dialog form for text input form user.";
            this.AccessibleName = "TextMessageBox";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelB;
            this.ClientSize = new System.Drawing.Size(461, 126);
            this.ControlBox = false;
            this.Controls.Add(this.Input);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.AcceptB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TextMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TextMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptB;
        private System.Windows.Forms.Button CancelB;
        private System.Windows.Forms.Label InfoLabel;
        /// <summary>
        /// Access to input data from other classes.
        /// </summary>
        public System.Windows.Forms.TextBox Input;
    }
}