namespace Binder
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tab = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Today = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddTask = new System.Windows.Forms.Button();
            this.DeleteTask = new System.Windows.Forms.Button();
            this.EditTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tab)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.AllowUserToOrderColumns = true;
            this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Tab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.Deadline,
            this.Today});
            this.Tab.Location = new System.Drawing.Point(12, 12);
            this.Tab.MultiSelect = false;
            this.Tab.Name = "Tab";
            this.Tab.ReadOnly = true;
            this.Tab.Size = new System.Drawing.Size(776, 395);
            this.Tab.TabIndex = 0;
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.Name = "TaskName";
            // 
            // Deadline
            // 
            this.Deadline.HeaderText = "Dead line";
            this.Deadline.Name = "Deadline";
            // 
            // Today
            // 
            this.Today.HeaderText = "Today?";
            this.Today.Name = "Today";
            // 
            // AddTask
            // 
            this.AddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddTask.Location = new System.Drawing.Point(12, 415);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(102, 23);
            this.AddTask.TabIndex = 1;
            this.AddTask.Text = "Add Task";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // DeleteTask
            // 
            this.DeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteTask.Location = new System.Drawing.Point(228, 415);
            this.DeleteTask.Name = "DeleteTask";
            this.DeleteTask.Size = new System.Drawing.Size(102, 23);
            this.DeleteTask.TabIndex = 2;
            this.DeleteTask.Text = "Delete Task";
            this.DeleteTask.UseVisualStyleBackColor = true;
            this.DeleteTask.Click += new System.EventHandler(this.DeleteTask_Click);
            // 
            // EditTask
            // 
            this.EditTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditTask.Location = new System.Drawing.Point(120, 415);
            this.EditTask.Name = "EditTask";
            this.EditTask.Size = new System.Drawing.Size(102, 23);
            this.EditTask.TabIndex = 3;
            this.EditTask.Text = "Edit Task";
            this.EditTask.UseVisualStyleBackColor = true;
            this.EditTask.Click += new System.EventHandler(this.EditTask_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditTask);
            this.Controls.Add(this.DeleteTask);
            this.Controls.Add(this.AddTask);
            this.Controls.Add(this.Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.Button DeleteTask;
        private System.Windows.Forms.Button EditTask;
        public System.Windows.Forms.DataGridView Tab;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Today;
    }
}

