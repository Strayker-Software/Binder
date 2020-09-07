using System;
using System.Windows.Forms;
using Binder.Tasks;

namespace Binder.UI
{
    /// <summary>
    /// Windows Form for getting task data from user.
    /// </summary>
    public partial class TaskForm : Form
    {
        private readonly IFormManager manager;

        /// <summary>
        /// Constructor for TaskForm dialog.
        /// </summary>
        /// <param name="Task">ITask object to save data to.</param>
        /// <param name="IfEdit">Indicates edit mode for form.</param>
        public TaskForm(ITask Task, bool IfEdit)
        {
            InitializeComponent();
            manager = new TaskFormManager(this, Task, IfEdit);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var mgr = (TaskFormManager)manager;
            mgr.OKButtonPressed();
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            var mgr = (TaskFormManager)manager;
            mgr.LoadForm();
        }
    }
}
