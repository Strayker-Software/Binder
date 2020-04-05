using System;
using System.Windows.Forms;

namespace Binder
{
    public partial class Main : Form
    {
        private readonly ITask Task;

        public Main()
        {
            InitializeComponent();
            Task = new Task();
        }

        /// <summary>
        /// Opens form to get data and adds data to grid.
        /// </summary>
        private void AddTask_Click(object sender, EventArgs e)
        {
            var frm = new TaskForm(Task, false); // ITask argument, no edit mode,
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK) Task.AddTask(Tab);
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
            }
            else
            {
                MessageBox.Show("Please select only one full row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTask_Click(object sender, EventArgs e)
        {
            var row = Tab.SelectedRows;
            Task.Name = (string)row[0].Cells[0].Value;
            Task.Date = (DateTime)row[0].Cells[1].Value;
            Task.IfToday = (CheckState)row[0].Cells[2].Value;
            var frm = new TaskForm(Task, true); // ITask argument, edit mode,
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK) Task.EditTask(Tab, row[0].Index);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
