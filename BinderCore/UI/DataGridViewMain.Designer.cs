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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.DataTab = new System.Windows.Forms.DataGridView();
            this.TabController = new System.Windows.Forms.TabControl();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.ManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.Page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTab)).BeginInit();
            this.TabController.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 637);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1090, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel1.Text = "Data saved";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // Page1
            // 
            this.Page1.BackColor = System.Drawing.Color.White;
            this.Page1.Controls.Add(this.DataTab);
            this.Page1.Location = new System.Drawing.Point(4, 24);
            this.Page1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page1.Size = new System.Drawing.Size(1054, 571);
            this.Page1.TabIndex = 0;
            this.Page1.Text = "Page1";
            // 
            // DataTab
            // 
            this.DataTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTab.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataTab.Location = new System.Drawing.Point(7, 7);
            this.DataTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DataTab.MultiSelect = false;
            this.DataTab.Name = "DataTab";
            this.DataTab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTab.Size = new System.Drawing.Size(1038, 555);
            this.DataTab.TabIndex = 0;
            // 
            // TabController
            // 
            this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabController.Controls.Add(this.Page1);
            this.TabController.Location = new System.Drawing.Point(14, 31);
            this.TabController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(1062, 599);
            this.TabController.TabIndex = 7;
            this.TabController.DoubleClick += new System.EventHandler(this.TabController_DoubleClick);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1090, 24);
            this.Menu.TabIndex = 8;
            this.Menu.Text = "menuStrip1";
            // 
            // ManagerToolStripMenuItem
            // 
            this.ManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTabToolStripMenuItem,
            this.DeleteTabToolStripMenuItem,
            this.toolStripSeparator,
            this.SaveToolStripMenuItem,
            this.SaveAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.ManagerToolStripMenuItem.Name = "ManagerToolStripMenuItem";
            this.ManagerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ManagerToolStripMenuItem.Text = "Manager";
            // 
            // NewTabToolStripMenuItem
            // 
            this.NewTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewTabToolStripMenuItem.Image")));
            this.NewTabToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewTabToolStripMenuItem.Name = "NewTabToolStripMenuItem";
            this.NewTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewTabToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.NewTabToolStripMenuItem.Text = "New Tab";
            this.NewTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItem_Click);
            // 
            // DeleteTabToolStripMenuItem
            // 
            this.DeleteTabToolStripMenuItem.Name = "DeleteTabToolStripMenuItem";
            this.DeleteTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DeleteTabToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.DeleteTabToolStripMenuItem.Text = "Delete Tab";
            this.DeleteTabToolStripMenuItem.Click += new System.EventHandler(this.DeleteTabToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(184, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAllToolStripMenuItem
            // 
            this.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem";
            this.SaveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.SaveAllToolStripMenuItem.Text = "Save All";
            this.SaveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskToolStripMenuItem,
            this.EditTaskToolStripMenuItem,
            this.DeleteTaskToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
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
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
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
            this.DevLabel.Location = new System.Drawing.Point(654, 644);
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
            this.ClientSize = new System.Drawing.Size(1090, 659);
            this.Controls.Add(this.DevLabel);
            this.Controls.Add(this.TabController);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DataGridViewMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.Page1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTab)).EndInit();
            this.TabController.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage Page1;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem ManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTaskToolStripMenuItem;
        private System.Windows.Forms.Label DevLabel;
        private System.Windows.Forms.DataGridView DataTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Today;

        /// <summary>
        /// For access across the app.
        /// </summary>
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.TabControl TabController;
    }
}

