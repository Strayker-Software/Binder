using Binder.Storages;
using Binder.Tasks;
using System.Windows.Forms;

namespace Binder.UI
{
    /// <summary>
    /// IFormManager class for to prepare TaskForm for user.
    /// </summary>
    public class TaskFormManager : IFormManager
    {
        /// <summary>
        /// ITask object for loading and saving tasks.
        /// </summary>
        public ITask Task { get; set; }
        /// <summary>
        /// IStorage object for loading and saving data to storage area.
        /// </summary>
        public IStorage Strgm { get; set; }
        private readonly bool IfEdit;
        private readonly TaskForm Frm;

        /// <summary>
        /// Constructor for TaskFormManager class.
        /// </summary>
        public TaskFormManager(TaskForm form, ITask task, bool editMode)
        {
            Frm = form;
            Task = task;
            IfEdit = editMode;
            // There's no need in setting IStorage object, this form will not use it,
        }

        /// <summary>
        /// Closes dialog and returns to calling instruction.
        /// </summary>
        /// <returns>Always true.</returns>
        public bool CloseForm()
        {
            return true;
        }

        /// <summary>
        /// Prepares text label for user.
        /// </summary>
        public bool LoadForm()
        {
            if (IfEdit)
            {
                Frm.NameTextBox.Text = Task.Name;
                Frm.DateTimePicker.Value = Task.Date;
                Frm.IfTodayBox.CheckState = Task.IfToday;
            }

            return true;
        }

        /// <summary>
        /// Method to handle data travel out of form.
        /// </summary>
        public void OKButtonPressed()
        {
            if (Frm.NameTextBox.Text == null || Frm.NameTextBox.Text == "")
            {
                MessageBox.Show("Add the name to the task!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm.DialogResult = DialogResult.Cancel;
                return;
            }

            Task.Name = Frm.NameTextBox.Text;
            Task.Date = Frm.DateTimePicker.Value;
            Task.IfToday = Frm.IfTodayBox.CheckState;
            Frm.Close();
        }
    }
}
