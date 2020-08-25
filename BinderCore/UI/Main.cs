using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Binder.Properties;

namespace Binder
{
    public partial class Main : Form
    {
        private readonly ITask Task;
        private readonly IStorage Strgm;

        /// <summary>
        /// Main class constructor.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SetDGV(DataTab);
            Task = new DataGridViewTask();
            Strgm = new DataGridViewStorageManagerXML();
#if DEBUG
            DevLabel.Text = "Binder v" + Application.ProductVersion + " - Strayker Software Development Build - Use only for dev operations";
            DevLabel.Visible = true;
            Settings.Default.Reset();
            foreach (string x in Directory.GetFiles("databases\\"))
            {
                File.Delete(x);
            }
            var stream = File.CreateText("databases\\Page1.xml");
            stream.Write("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            stream.Close();
#endif
        }

        /// <summary>
        /// Set default settings for DataGridView. Workover for .NET Core Designer bugs.
        /// </summary>
        /// <param name="tab">DataGridView object to add columns to.</param>
        public void SetDGV(DataGridView tab)
        {
            // Set DataGridView properties:
            tab.ReadOnly = true;

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
            Today = new DataGridViewCheckBoxColumn
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
            // Sort the tabs' names alphabetically:
            var list = new List<string>();
            foreach (string a in Settings.Default.Pages)
            {
                list.Add(a);
            }
            list.Sort();

            // For each tab, create table in app's window:
            // Workover for Designer-made Page1 tab,
            TabController.TabPages[0].Name = list[0]; 
            TabController.TabPages[0].Text = list[0];
            list.RemoveAt(0);
            foreach (string b in list)
            {
                var frm = new Main();
                var tab = frm.DataTab;
                // Size values, I don't know why this values are working :/
                tab.Width = 184;
                tab.Height = 84;
                var pg = new TabPage
                {
                    Name = b,
                    Text = b
                };
                pg.BackColor = Color.White;
                pg.Controls.Add(tab);
                TabController.TabPages.Add(pg);
            }

            // For each tab, check and load data:
            foreach (TabPage c in TabController.TabPages)
            {
                try
                {
                    Strgm.StorageAccess = "databases\\" + c.Name + ".xml";
                    Strgm.Tab = (DataGridView)c.Controls[0];
                    Strgm.LoadFromStorage();
                }
                catch (Exception a)
                { // TODO: Create custom Exception system!
                    if (a.GetType() == typeof(FileNotFoundException))
                    {
                        MessageBox.Show("Error 2: Database not found. Check if database exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(2);
                    }
                    else if (a.GetType() == typeof(ArgumentException))
                    {
                        MessageBox.Show("Error 1: Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                    else
                    {
                        MessageBox.Show("Error -1: There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);
                    }
                }
            }
        }

        /// <summary>
        /// Executed on main form's closing.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask if user relly want to exit:
            var dialog = MessageBox.Show("Are you sure you want to exit Binder? All task tables will be saved.", "Binder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                // Iterate through all tabs and save data:
                foreach (TabPage item in TabController.TabPages)
                {
                    try
                    {
                        Strgm.StorageAccess = "databases\\" + item.Name + ".xml";
                        Strgm.Tab = (DataGridView)item.Controls[0];
                        Strgm.SaveToStorage();
                    }
                    catch (Exception a)
                    {
                        if (a.GetType() == typeof(FileNotFoundException))
                        {
                            MessageBox.Show("Error 2 for " + item.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                        else if (a.GetType() == typeof(ArgumentException))
                        {
                            MessageBox.Show("Error 1 for " + item.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                        else
                        {
                            MessageBox.Show("Error -1 for " + item.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creates new tab with separate table.
        /// </summary>
        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

                    if (File.Exists("databases\\" + dialog.Input.Text + ".xml"))
                    {
                        MessageBox.Show("Can't create the database file: database already exists!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                    var stream = File.CreateText("databases\\" + dialog.Input.Text + ".xml");
                    stream.Write("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
                    stream.Close();
                    Settings.Default.Pages.Add(dialog.Input.Text);
                    Settings.Default.Save();
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
        {
            if(TabController.TabPages.Count > 1)
            {
                var tab = TabController.SelectedTab;
                File.Delete("databases\\" + tab.Name + ".xml");
                Settings.Default.Pages.Remove(tab.Name);
                TabController.TabPages.Remove(tab);
            }
            else
            {
                MessageBox.Show("You can't delete any more tabs.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save current tab data to database.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Strgm.StorageAccess = "databases\\" + TabController.SelectedTab.Name + ".xml";
                Strgm.Tab = (DataGridView)TabController.SelectedTab.Controls[0];
                Strgm.SaveToStorage();
                statusStrip.Items[0].Text = "Data from " + TabController.SelectedTab.Text + " saved!";
                statusStrip.Items[0].Visible = true;
            }
            catch (Exception a)
            {
                if (a.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("Error 2 for " + TabController.SelectedTab.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (a.GetType() == typeof(ArgumentException))
                {
                    MessageBox.Show("Error 1 for " + TabController.SelectedTab.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error -1 for " + TabController.SelectedTab.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Saves all tabs to databases respectively.
        /// </summary>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // For each tab, make the save operation:
            foreach (TabPage item in TabController.TabPages)
            {
                try
                {
                    Strgm.StorageAccess = "databases\\" + item.Name + ".xml";
                    Strgm.Tab = (DataGridView)item.Controls[0];
                    Strgm.SaveToStorage();
                }
                catch (Exception a)
                {
                    if (a.GetType() == typeof(FileNotFoundException))
                    {
                        MessageBox.Show("Error 2 for " + item.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (a.GetType() == typeof(ArgumentException))
                    {
                        MessageBox.Show("Error 1 for " + item.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error -1 for " + item.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            statusStrip.Items[0].Text = "All data saved!";
            statusStrip.Items[0].Visible = true;
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
                var tabpage = TabController.SelectedTab;
                Task.Destination = (DataGridView)tabpage.Controls[0];
                Task.AddTask();
                statusStrip.Items[0].Visible = false;
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tab = (DataGridView)TabController.SelectedTab.Controls[0];

            if (tab.AreAllCellsSelected(false) == false && tab.SelectedRows.Count != 0)
            {
                var row = tab.SelectedRows[0];

                Task.Name = (string)row.Cells[0].Value;
                Task.Date = (DateTime)row.Cells[1].Value;
                Task.IfToday = (CheckState)row.Cells[2].Value;

                var frm = new TaskForm(Task, true); // ITask argument, edit mode,
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Task.Destination = tab;
                    Task.TaskId = row.Index;
                    Task.EditTask();
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
            var tab = (DataGridView)TabController.SelectedTab.Controls[0];
            var row = tab.SelectedRows;

            if (tab.AreAllCellsSelected(false) == false && tab.SelectedRows.Count != 0)
            {
                tab.Rows.Remove(row[0]);
                tab.Refresh();
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
        { // TODO: Add settings window!
            
        }

        /// <summary>
        /// Shows about app window.
        /// </summary>
        private void AboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        { // TODO: Add library with this window!

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
                    if (File.Exists("databases//" + tab.Name + ".xml")) File.Move("databases//" + tab.Name + ".xml", "databases//" + dialog.Input.Text + ".xml");
                    else
                    {
                        MessageBox.Show("Can't find the database file to change the name!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Settings.Default.Pages.Remove(tab.Name);
                    Settings.Default.Pages.Add(dialog.Input.Text);
                    Settings.Default.Save();
                    tab.Name = dialog.Input.Text;
                    tab.Text = dialog.Input.Text;
                }
            }
        }
    }
}
