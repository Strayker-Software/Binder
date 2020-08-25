using System;
using System.Windows.Forms;

namespace Binder
{
    /// <summary>
    /// Windows Form for getting task data from user.
    /// </summary>
    public partial class TaskForm : Form
    {
        private readonly ITask Task;
        private readonly bool IfEdit;

        /// <summary>
        /// Task form constructor.
        /// </summary>
        /// <param name="Task">ITask object to save data to.</param>
        /// <param name="IfEdit">Indicates edit mode for form.</param>
        public TaskForm(ITask Task, bool IfEdit)
        {
            InitializeComponent();
            this.Task = Task;
            this.IfEdit = IfEdit;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == null || NameTextBox.Text == "")
            {
                MessageBox.Show("Add the name to the task!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                return;
            }

            Task.Name = NameTextBox.Text;
            Task.Date = DateTimePicker.Value;
            Task.IfToday = IfTodayBox.CheckState;
            Close();
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            if(IfEdit)
            {
                NameTextBox.Text = Task.Name;
                DateTimePicker.Value = Task.Date;
                IfTodayBox.CheckState = Task.IfToday;
            }
        }
    }
}
