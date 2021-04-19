
namespace Binder.UI.Dialog
{
    partial class StringInputDialog
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
            this.InfoLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.DialogAcceptButton = new System.Windows.Forms.Button();
            this.DialogCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(12, 9);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(56, 15);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "InfoLabel";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 27);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(275, 23);
            this.InputTextBox.TabIndex = 1;
            // 
            // DialogAcceptButton
            // 
            this.DialogAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DialogAcceptButton.Location = new System.Drawing.Point(131, 116);
            this.DialogAcceptButton.Name = "DialogAcceptButton";
            this.DialogAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.DialogAcceptButton.TabIndex = 2;
            this.DialogAcceptButton.Text = "DialogAcceptButton";
            this.DialogAcceptButton.UseVisualStyleBackColor = true;
            this.DialogAcceptButton.Click += new System.EventHandler(this.DialogAcceptButton_Click);
            // 
            // DialogCancelButton
            // 
            this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DialogCancelButton.Location = new System.Drawing.Point(212, 116);
            this.DialogCancelButton.Name = "DialogCancelButton";
            this.DialogCancelButton.Size = new System.Drawing.Size(75, 23);
            this.DialogCancelButton.TabIndex = 3;
            this.DialogCancelButton.Text = "DialogCancelButton";
            this.DialogCancelButton.UseVisualStyleBackColor = true;
            // 
            // StringInputDialog
            // 
            this.AcceptButton = this.DialogAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DialogCancelButton;
            this.ClientSize = new System.Drawing.Size(299, 151);
            this.ControlBox = false;
            this.Controls.Add(this.DialogCancelButton);
            this.Controls.Add(this.DialogAcceptButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StringInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StringInputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button DialogAcceptButton;
        private System.Windows.Forms.Button DialogCancelButton;
    }
}