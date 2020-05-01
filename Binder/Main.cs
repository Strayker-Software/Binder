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
            Strgm = new StorageManager();
        }

        /// <summary>
        /// Opens form to get data and adds data to grid.
        /// </summary>
        private void AddTask_Click(object sender, EventArgs e)
        {
            var frm = new TaskForm(Task, false); // ITask argument, no edit mode,
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Task.AddTask(Tab);
                statusStrip.Items[0].Visible = false;
            }
        }

        /// <summary>
        /// Deletes selected row from grid.
        /// </summary>
        private void DeleteTask_Click(object sender, EventArgs e)
        {
            if(Tab.AreAllCellsSelected(false) == false && Tab.SelectedRows.Count != 0)
            {
                var row = Tab.SelectedRows;
                Tab.Rows.Remove(row[0]);
                Tab.Refresh();
                statusStrip.Items[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTask_Click(object sender, EventArgs e)
        {
            var row = Tab.SelectedRows;

            if (Tab.AreAllCellsSelected(false) == false && Tab.SelectedRows.Count != 0)
            {
                Task.Name = (string)row[0].Cells[0].Value;
                Task.Date = (DateTime)row[0].Cells[1].Value;
                Task.IfToday = (CheckState)row[0].Cells[2].Value;

                var frm = new TaskForm(Task, true); // ITask argument, edit mode,
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Task.EditTask(Tab, row[0].Index);
                    statusStrip.Items[0].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Exectued on main form's start.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Strgm.StoragePath = "Data.xml";
                Strgm.Tab = Tab;
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

        /// <summary>
        /// Executed on main form's closing.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Strgm.StoragePath = "Data.xml";
                Strgm.Tab = Tab;
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
        /// Saves data to database by button.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Strgm.StoragePath = "Data.xml";
                Strgm.Tab = Tab;
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
    }
}
