using System;
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
            Task = new Task();
            Strgm = new StorageManagerXML();
#if DEBUG
            DevLabel.Visible = true;
#endif
        }

        /// <summary>
        /// Exectued on main form's start.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            GridCreate(); // Description in method's code,

            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = Tab1;
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
        }

        public void GridCreate()
        {
            /*
            After migration of Binder to .NET Core 3.1 DataGridView component broke down.
            The Designer crushed every time I tried to write down these lines of code,
            so I pushed them here and everything is working now.
            Maybe it's problem with DataGridView support in .NET Core.
             */

            TaskName = new DataGridViewTextBoxColumn();
            Deadline = new DataGridViewTextBoxColumn();
            Today = new DataGridViewCheckBoxColumn();
            // TaskName
            TaskName.HeaderText = "Task Name";
            TaskName.Name = "TaskName";
            TaskName.ReadOnly = true;
            // Deadline
            Deadline.HeaderText = "Dead line";
            Deadline.Name = "Deadline";
            Deadline.ReadOnly = true;
            // Today
            Today.HeaderText = "Today?";
            Today.Name = "Today";
            Today.ReadOnly = true;

            Tab1.Columns.Add(TaskName);
            Tab1.Columns.Add(Deadline);
            Tab1.Columns.Add(Today);
        }

        /// <summary>
        /// Executed on main form's closing.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = Tab1;
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
        }

        /// <summary>
        /// Creates new tab with separate table.
        /// </summary>
        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deletes active tab and data.
        /// </summary>
        private void DeleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Save current tab data to database.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Strgm.StorageAccess = "Data.xml";
                Strgm.Tab = Tab1;
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
                Task.AddTask(Tab1);
                statusStrip.Items[0].Visible = false;
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = Tab1.SelectedRows;

            if (Tab1.AreAllCellsSelected(false) == false && Tab1.SelectedRows.Count != 0)
            {
                Task.Name = (string)row[0].Cells[0].Value;
                Task.Date = (DateTime)row[0].Cells[1].Value;
                Task.IfToday = (CheckState)row[0].Cells[2].Value;

                var frm = new TaskForm(Task, true); // ITask argument, edit mode,
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Task.EditTask(Tab1, row[0].Index);
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
            if (Tab1.AreAllCellsSelected(false) == false && Tab1.SelectedRows.Count != 0)
            {
                var row = Tab1.SelectedRows;
                Tab1.Rows.Remove(row[0]);
                Tab1.Refresh();
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
    }
}
