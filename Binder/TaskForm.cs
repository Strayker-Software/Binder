using System;
using System.Windows.Forms;

namespace Binder
{
    public partial class TaskForm : Form
    {
        private readonly ITask Task;

        public TaskForm(ITask Task)
        {
            InitializeComponent();
            this.Task = Task;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            
        }
    }
}
