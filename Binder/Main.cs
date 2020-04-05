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

        private void AddTask_Click(object sender, EventArgs e)
        {
            var frm = new TaskForm(Task); // ITask argument,
            frm.ShowDialog();
        }

        private void DeleteTask_Click(object sender, EventArgs e)
        {
            
        }

        private void EditTask_Click(object sender, EventArgs e)
        {

        }

        private void Tab_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
