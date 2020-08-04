using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Binder
{
    public partial class Main : Form
    {
        private readonly ITask Task;
        private readonly IStorage Strgm;

        public Main()
        {
            InitializeComponent();
            AddColumns(DataTab);
            Task = new Task();
            Strgm = new StorageManagerXML();
#if DEBUG
            DevLabel.Visible = true;
#endif
        }

        /// <summary>
        /// Adds default columns to DataGridView. Workover for .NET Core Designer bug.
        /// </summary>
        /// <param name="tab">DataGridView object to add columns to.</param>
        private void AddColumns(DataGridView tab)
        {
            // TaskName
            TaskName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Task Name",
                Name = "TaskName"
            };
            // Deadline
            Deadline = new DataGridViewTextBoxColumn
            {
                HeaderText = "Deadline",
                Name = "Deadline"
            };
            // Today
            Today = new DataGridViewTextBoxColumn
            {
                HeaderText = "Today?",
                Name = "Today"
            };

            tab.Columns.AddRange(TaskName, Deadline, Today);
        }

        /// <summary>
        /// Exectued on main form's start.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = DataTab;
                Strgm.LoadFromStorage();
            }
            catch (Exception a)
            {
                if(a.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("Error 2: Database not found. Check if database exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(2);
                }
                else if(a.GetType() == typeof(ArgumentException))
                {
                    MessageBox.Show("Error 1: Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                else
                {
                    MessageBox.Show("Error 0: There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            */
        }

        /// <summary>
        /// Executed on main form's closing.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = DataTab;
                Strgm.SaveToStorage();
            }
            catch (Exception a)
            {
                if (a.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("Error 2: Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(2);
                }
                else if (a.GetType() == typeof(ArgumentException))
                {
                    MessageBox.Show("Error 1: Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                else
                {
                    MessageBox.Show("Error 0: There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            */
        }

        /// <summary>
        /// Creates new tab with separate table.
        /// </summary>
        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        { // TODO: Add database creation!
            var dialog = new TextMessageBox("Please write name of new data tab here:");
            dialog.ShowDialog();

            if(dialog.DialogResult == DialogResult.OK)
            {
                if(dialog.Input.Text != "" && dialog.Input.Text != null)
                {
                    foreach(TabPage x in TabController.TabPages)
                    {
                        if(dialog.Input.Text == x.Name)
                        {
                            MessageBox.Show("Tab with this name already exist.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    var frm = new Main();
                    var tab = frm.DataTab;
                    // Size values, I don't know why this values are working :/
                    tab.Width = 184;
                    tab.Height = 84;

                    var pg = new TabPage
                    {
                        Name = dialog.Input.Text,
                        Text = dialog.Input.Text
                    };
                    pg.BackColor = Color.White;
                    pg.Controls.Add(tab);
                    TabController.TabPages.Add(pg);
                }
                else
                {
                    MessageBox.Show("You have to write name for new tab!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Deletes active tab and data.
        /// </summary>
        private void DeleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {// TODO: Add database removement!
            var tab = TabController.SelectedTab;

            TabController.TabPages.Remove(tab);

            tab.Dispose();
        }

        /// <summary>
        /// Save current tab data to database.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = DataTab;
                Strgm.SaveToStorage();
                statusStrip.Items[0].Visible = true;
            }
            catch (Exception a)
            {
                if (a.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("Error 2: Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(2);
                }
                else if (a.GetType() == typeof(ArgumentException))
                {
                    MessageBox.Show("Error 1: Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                else
                {
                    MessageBox.Show("Error 0: There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Saves all tabs to databases respectively.
        /// </summary>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Opens form to get data and adds data to grid.
        /// </summary>
        private void AddTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TaskForm(Task, false); // ITask argument, no edit mode,
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Task.AddTask(DataTab);
                statusStrip.Items[0].Visible = false;
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = DataTab.SelectedRows;

            if (DataTab.AreAllCellsSelected(false) == false && DataTab.SelectedRows.Count != 0)
            {
                Task.Name = (string)row[0].Cells[0].Value;
                Task.Date = (DateTime)row[0].Cells[1].Value;
                Task.IfToday = (CheckState)row[0].Cells[2].Value;

                var frm = new TaskForm(Task, true); // ITask argument, edit mode,
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Task.EditTask(DataTab, row[0].Index);
                    statusStrip.Items[0].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Deletes selected row from grid.
        /// </summary>
        private void DeleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataTab.AreAllCellsSelected(false) == false && DataTab.SelectedRows.Count != 0)
            {
                var row = DataTab.SelectedRows;
                DataTab.Rows.Remove(row[0]);
                DataTab.Refresh();
                statusStrip.Items[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Shows up settings screen.
        /// </summary>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Shows about app window.
        /// </summary>
        private void AboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Handles name change of existing tab.
        /// </summary>
        private void TabController_DoubleClick(object sender, EventArgs e)
        {
            var dialog = new TextMessageBox("Please write new name for this tab:");
            dialog.ShowDialog();
            
            if(dialog.DialogResult == DialogResult.OK)
            {
                if(dialog.Input.Text != "" && dialog.Input.Text != null)
                {
                    var tab = TabController.SelectedTab;
                    tab.Name = dialog.Input.Text;
                    tab.Text = dialog.Input.Text;
                }
            }
        }
    }
}
