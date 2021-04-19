
namespace Binder.UI.Dialog
{
    partial class StandardTaskForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DialogAcceptButton = new System.Windows.Forms.Button();
            this.DialogCancelButton = new System.Windows.Forms.Button();
            this.NoDateTask = new System.Windows.Forms.CheckBox();
            this.HelpBox = new System.Windows.Forms.GroupBox();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.CategoryListComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryListLabel = new System.Windows.Forms.Label();
            this.HelpBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(67, 15);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "NameLabel";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(12, 27);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(353, 23);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 53);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(95, 15);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "DescriptionLabel";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(12, 71);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(353, 23);
            this.DescriptionTextBox.TabIndex = 3;
            this.DescriptionTextBox.Enter += new System.EventHandler(this.DescriptionTextBox_Enter);
            this.DescriptionTextBox.Leave += new System.EventHandler(this.DescriptionTextBox_Leave);
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(3, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(83, 15);
            this.StartDateLabel.TabIndex = 9;
            this.StartDateLabel.Text = "StartDateLabel";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDatePicker.Location = new System.Drawing.Point(3, 18);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(350, 23);
            this.StartDatePicker.TabIndex = 10;
            this.StartDatePicker.Enter += new System.EventHandler(this.StartDatePicker_Enter);
            this.StartDatePicker.Leave += new System.EventHandler(this.StartDatePicker_Leave);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(3, 44);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(79, 15);
            this.EndDateLabel.TabIndex = 11;
            this.EndDateLabel.Text = "EndDateLabel";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EndDatePicker.Location = new System.Drawing.Point(3, 62);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(350, 23);
            this.EndDatePicker.TabIndex = 12;
            this.EndDatePicker.Enter += new System.EventHandler(this.EndDatePicker_Enter);
            this.EndDatePicker.Leave += new System.EventHandler(this.EndDatePicker_Leave);
            // 
            // DialogAcceptButton
            // 
            this.DialogAcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DialogAcceptButton.Location = new System.Drawing.Point(12, 404);
            this.DialogAcceptButton.Name = "DialogAcceptButton";
            this.DialogAcceptButton.Size = new System.Drawing.Size(173, 23);
            this.DialogAcceptButton.TabIndex = 15;
            this.DialogAcceptButton.Text = "DialogAcceptButton";
            this.DialogAcceptButton.UseVisualStyleBackColor = true;
            this.DialogAcceptButton.Click += new System.EventHandler(this.DialogAcceptButton_Click);
            // 
            // DialogCancelButton
            // 
            this.DialogCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DialogCancelButton.Location = new System.Drawing.Point(192, 404);
            this.DialogCancelButton.Name = "DialogCancelButton";
            this.DialogCancelButton.Size = new System.Drawing.Size(173, 23);
            this.DialogCancelButton.TabIndex = 16;
            this.DialogCancelButton.Text = "DialogCancelButton";
            this.DialogCancelButton.UseVisualStyleBackColor = true;
            this.DialogCancelButton.Click += new System.EventHandler(this.DialogCancelButton_Click);
            // 
            // NoDateTask
            // 
            this.NoDateTask.AutoSize = true;
            this.NoDateTask.Location = new System.Drawing.Point(12, 169);
            this.NoDateTask.Name = "NoDateTask";
            this.NoDateTask.Size = new System.Drawing.Size(88, 19);
            this.NoDateTask.TabIndex = 7;
            this.NoDateTask.Text = "NoDateTask";
            this.NoDateTask.UseVisualStyleBackColor = true;
            this.NoDateTask.CheckedChanged += new System.EventHandler(this.NoDateTask_CheckedChanged);
            this.NoDateTask.Enter += new System.EventHandler(this.NoDateTask_Enter);
            this.NoDateTask.Leave += new System.EventHandler(this.NoDateTask_Leave);
            // 
            // HelpBox
            // 
            this.HelpBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBox.Controls.Add(this.HelpLabel);
            this.HelpBox.Location = new System.Drawing.Point(12, 296);
            this.HelpBox.Name = "HelpBox";
            this.HelpBox.Size = new System.Drawing.Size(353, 102);
            this.HelpBox.TabIndex = 13;
            this.HelpBox.TabStop = false;
            this.HelpBox.Text = "HelpBox";
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Location = new System.Drawing.Point(7, 19);
            this.HelpLabel.MaximumSize = new System.Drawing.Size(340, 0);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(60, 15);
            this.HelpLabel.TabIndex = 14;
            this.HelpLabel.Text = "HelpLabel";
            this.HelpLabel.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.StartDateLabel);
            this.flowLayoutPanel1.Controls.Add(this.StartDatePicker);
            this.flowLayoutPanel1.Controls.Add(this.EndDateLabel);
            this.flowLayoutPanel1.Controls.Add(this.EndDatePicker);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 194);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(353, 96);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // CompleteCheckBox
            // 
            this.CompleteCheckBox.AutoSize = true;
            this.CompleteCheckBox.Location = new System.Drawing.Point(12, 144);
            this.CompleteCheckBox.Name = "CompleteCheckBox";
            this.CompleteCheckBox.Size = new System.Drawing.Size(131, 19);
            this.CompleteCheckBox.TabIndex = 6;
            this.CompleteCheckBox.Text = "CompleteCheckBox";
            this.CompleteCheckBox.UseVisualStyleBackColor = true;
            this.CompleteCheckBox.Enter += new System.EventHandler(this.CompleteCheckBox_Enter);
            this.CompleteCheckBox.Leave += new System.EventHandler(this.CompleteCheckBox_Leave);
            // 
            // CategoryListComboBox
            // 
            this.CategoryListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryListComboBox.FormattingEnabled = true;
            this.CategoryListComboBox.Location = new System.Drawing.Point(12, 115);
            this.CategoryListComboBox.Name = "CategoryListComboBox";
            this.CategoryListComboBox.Size = new System.Drawing.Size(353, 23);
            this.CategoryListComboBox.TabIndex = 5;
            this.CategoryListComboBox.Enter += new System.EventHandler(this.CategoryListComboBox_Enter);
            this.CategoryListComboBox.Leave += new System.EventHandler(this.CategoryListComboBox_Leave);
            // 
            // CategoryListLabel
            // 
            this.CategoryListLabel.AutoSize = true;
            this.CategoryListLabel.Location = new System.Drawing.Point(12, 97);
            this.CategoryListLabel.Name = "CategoryListLabel";
            this.CategoryListLabel.Size = new System.Drawing.Size(101, 15);
            this.CategoryListLabel.TabIndex = 4;
            this.CategoryListLabel.Text = "CategoryListLabel";
            // 
            // StandardTaskForm
            // 
            this.AcceptButton = this.DialogAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DialogCancelButton;
            this.ClientSize = new System.Drawing.Size(377, 436);
            this.ControlBox = false;
            this.Controls.Add(this.CategoryListComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.HelpBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.CompleteCheckBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.CategoryListLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DialogCancelButton);
            this.Controls.Add(this.DialogAcceptButton);
            this.Controls.Add(this.NoDateTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StandardTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskForm";
            this.HelpBox.ResumeLayout(false);
            this.HelpBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Button DialogAcceptButton;
        private System.Windows.Forms.Button DialogCancelButton;
        private System.Windows.Forms.CheckBox NoDateTask;
        private System.Windows.Forms.GroupBox HelpBox;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox CompleteCheckBox;
        private System.Windows.Forms.ComboBox CategoryListComboBox;
        private System.Windows.Forms.Label CategoryListLabel;
    }
}