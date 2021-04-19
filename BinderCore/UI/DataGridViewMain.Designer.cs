namespace Binder.UI
{
    /// <summary>
    /// First part of Main class.
    /// </summary>
    partial class DataGridViewMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridViewMain));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.DataStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabController = new System.Windows.Forms.TabControl();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.ManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHideCompletedTaskListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevLabel = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 539);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1089, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 5;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // DataStatusLabel
            // 
            this.DataStatusLabel.Name = "DataStatusLabel";
            this.DataStatusLabel.Size = new System.Drawing.Size(91, 17);
            this.DataStatusLabel.Text = "DataStatusLabel";
            this.DataStatusLabel.Visible = false;
            // 
            // TabController
            // 
            this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabController.Location = new System.Drawing.Point(14, 31);
            this.TabController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(1061, 501);
            this.TabController.TabIndex = 7;
            this.TabController.DoubleClick += new System.EventHandler(this.TabController_DoubleClick);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerToolStripMenuItem,
            this.DataToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1089, 24);
            this.Menu.TabIndex = 8;
            this.Menu.Text = "menuStrip1";
            // 
            // ManagerToolStripMenuItem
            // 
            this.ManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTabToolStripMenuItem,
            this.DeleteTabToolStripMenuItem,
            this.ShowHideCompletedTaskListMenuItem,
            this.toolStripSeparator,
            this.SaveToolStripMenuItem,
            this.SaveAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.ManagerToolStripMenuItem.Name = "ManagerToolStripMenuItem";
            this.ManagerToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.ManagerToolStripMenuItem.Text = "ManagerToolStripMenuItem";
            // 
            // NewTabToolStripMenuItem
            // 
            this.NewTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewTabToolStripMenuItem.Image")));
            this.NewTabToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewTabToolStripMenuItem.Name = "NewTabToolStripMenuItem";
            this.NewTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewTabToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.NewTabToolStripMenuItem.Text = "HelpToolStripMenuItem";
            this.NewTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItem_Click);
            // 
            // DeleteTabToolStripMenuItem
            // 
            this.DeleteTabToolStripMenuItem.Name = "DeleteTabToolStripMenuItem";
            this.DeleteTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DeleteTabToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.DeleteTabToolStripMenuItem.Text = "DeleteTabToolStripMenuItem";
            this.DeleteTabToolStripMenuItem.Click += new System.EventHandler(this.DeleteTabToolStripMenuItem_Click);
            // 
            // ShowHideCompletedTaskListMenuItem
            // 
            this.ShowHideCompletedTaskListMenuItem.CheckOnClick = true;
            this.ShowHideCompletedTaskListMenuItem.Name = "ShowHideCompletedTaskListMenuItem";
            this.ShowHideCompletedTaskListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.ShowHideCompletedTaskListMenuItem.Size = new System.Drawing.Size(325, 22);
            this.ShowHideCompletedTaskListMenuItem.Text = "ShowHideCompletedTaskListMenuItem";
            this.ShowHideCompletedTaskListMenuItem.Click += new System.EventHandler(this.ShowHideCompletedTaskListMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(322, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.SaveToolStripMenuItem.Text = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAllToolStripMenuItem
            // 
            this.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem";
            this.SaveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.SaveAllToolStripMenuItem.Text = "SaveAllToolStripMenuItem";
            this.SaveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(322, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.ExitToolStripMenuItem.Text = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // DataToolStripMenuItem
            // 
            this.DataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskToolStripMenuItem,
            this.EditTaskToolStripMenuItem,
            this.DeleteTaskToolStripMenuItem});
            this.DataToolStripMenuItem.Name = "DataToolStripMenuItem";
            this.DataToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.DataToolStripMenuItem.Text = "DataToolStripMenuItem";
            // 
            // AddTaskToolStripMenuItem
            // 
            this.AddTaskToolStripMenuItem.Name = "AddTaskToolStripMenuItem";
            this.AddTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddTaskToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.AddTaskToolStripMenuItem.Text = "Add Task";
            this.AddTaskToolStripMenuItem.Click += new System.EventHandler(this.AddTaskToolStripMenuItem_Click);
            // 
            // EditTaskToolStripMenuItem
            // 
            this.EditTaskToolStripMenuItem.Name = "EditTaskToolStripMenuItem";
            this.EditTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditTaskToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.EditTaskToolStripMenuItem.Text = "Edit Task";
            this.EditTaskToolStripMenuItem.Click += new System.EventHandler(this.EditTaskToolStripMenuItem_Click);
            // 
            // DeleteTaskToolStripMenuItem
            // 
            this.DeleteTaskToolStripMenuItem.Name = "DeleteTaskToolStripMenuItem";
            this.DeleteTaskToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteTaskToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.DeleteTaskToolStripMenuItem.Text = "Delete Task";
            this.DeleteTaskToolStripMenuItem.Click += new System.EventHandler(this.DeleteTaskToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.AboutAppToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.HelpToolStripMenuItem.Text = "HelpToolStripMenuItem";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // AboutAppToolStripMenuItem
            // 
            this.AboutAppToolStripMenuItem.Name = "AboutAppToolStripMenuItem";
            this.AboutAppToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.AboutAppToolStripMenuItem.Text = "About App";
            this.AboutAppToolStripMenuItem.Click += new System.EventHandler(this.AboutAppToolStripMenuItem_Click);
            // 
            // DevLabel
            // 
            this.DevLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DevLabel.AutoSize = true;
            this.DevLabel.Location = new System.Drawing.Point(650, 546);
            this.DevLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DevLabel.Name = "DevLabel";
            this.DevLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DevLabel.Size = new System.Drawing.Size(55, 15);
            this.DevLabel.TabIndex = 9;
            this.DevLabel.Text = "DevLabel";
            this.DevLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DevLabel.Visible = false;
            // 
            // DataGridViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 561);
            this.Controls.Add(this.DevLabel);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.TabController);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1105, 600);
            this.Name = "DataGridViewMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataGridViewMain_FormClosing);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel DataStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AboutAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTaskToolStripMenuItem;
        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.Label DevLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem ManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowHideCompletedTaskListMenuItem;
    }
}

