using System;
using System.Globalization;
using System.Windows.Forms;
using Binder.Properties;
using Binder.Properties.Languages;
using Binder.Task;
using Binder.Task.Factories;

namespace Binder.UI.Dialog
{
    public partial class StandardTaskForm : Form, IDialog
    {
        private readonly ITaskFactory taskFactory = new TaskFactory();
        private readonly bool EditMode;

        public object ReturnValue { get; private set; }

        public StandardTaskForm()
        {
            InitializeComponent();
            
            // Set texts:
            Text = ResourceTaskForm.FormTitleAddition;
            NameLabel.Text = ResourceTaskForm.NameLabelText;
            DescriptionLabel.Text = ResourceTaskForm.DescriptionLabelText;
            CategoryListLabel.Text = ResourceTaskForm.CategoryListLabelText;
            CompleteCheckBox.Text = ResourceTaskForm.CompleteCheckBoxText;
            NoDateTask.Text = ResourceTaskForm.NoDateTaskText;
            StartDateLabel.Text = ResourceTaskForm.StartDateLabelText;
            EndDateLabel.Text = ResourceTaskForm.EndDateLabelText;
            HelpBox.Text = ResourceTaskForm.HelpBoxText;
            DialogAcceptButton.Text = ResourceTaskForm.DialogAcceptButtonText;
            DialogCancelButton.Text = ResourceTaskForm.DialogCancelButtonText;

            // Set data format for user's culture:
            StartDatePicker.Format = DateTimePickerFormat.Custom;
            StartDatePicker.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;

            EndDatePicker.Format = DateTimePickerFormat.Custom;
            EndDatePicker.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;

            // Set categories in collection:
            foreach (var item in Settings.Default.Categories)
            {
                CategoryListComboBox.Items.Add(item);
            }

            // Add extra default category:
            CategoryListComboBox.Items.Add(ResourceTaskForm.NoCategoryComboBoxText);

            // Set form's default behavior:
            NoDateTask.Checked = true;

            EditMode = false;
        }

        public StandardTaskForm(ITask task)
            : this()
        { // Edit mode:
            NameTextBox.Text = task.Name;
            DescriptionTextBox.Text = task.Description;
            CategoryListComboBox.SelectedItem = task.Category;
            CompleteCheckBox.Checked = task.Complete;
            StartDatePicker.Value = task.StartDate;
            if(task.EndDate == DateTime.MinValue) // No deadline:
                NoDateTask.Checked = true;
            else
            {
                NoDateTask.Checked = false;
                EndDatePicker.Value = task.EndDate;
            }

            Text = string.Format(ResourceTaskForm.FormTitleEdit, task.Name);
            EditMode = true;
        }

        public void AskUser()
        {
            ShowDialog();
        }

        public bool IsDataProvided()
        {
            if (ReturnValue != null) return true;
            else return false;
        }

        private void NoDateTask_CheckedChanged(object sender, EventArgs e)
        {
            if (NoDateTask.Checked) flowLayoutPanel1.Visible = false;
            else if(!NoDateTask.Checked) flowLayoutPanel1.Visible = true;
        }

        // User accepted form:
        private void DialogAcceptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                ReturnValue = null;
                return;
            }

            var obj = taskFactory.GetTask(ETask.Standard);
            // If category is set to default:
            if ((string)CategoryListComboBox.SelectedItem == ResourceTaskForm.NoCategoryComboBoxText)
                obj.Category = Resources.DefaultTaskCategoryName;
            // If no category was selected, select default one:
            else if (CategoryListComboBox.SelectedItem == null)
                obj.Category = Resources.DefaultTaskCategoryName;
            else obj.Category = CategoryListComboBox.SelectedItem.ToString();

            // Make sure, that task object will be configured to "no deadline" case correctly, based form mode:
            if (!EditMode)
            {
                if (!NoDateTask.Checked)
                {
                    obj.StartDate = StartDatePicker.Value;
                    obj.EndDate = EndDatePicker.Value;
                }
                else obj.StartDate = DateTime.Now;
            }
            else
            {
                if (!NoDateTask.Checked)
                {
                    obj.StartDate = StartDatePicker.Value;
                    obj.EndDate = EndDatePicker.Value;
                }
                else obj.StartDate = StartDatePicker.Value;
            }

            obj.Name = NameTextBox.Text;
            obj.Description = DescriptionTextBox.Text;
            obj.Complete = CompleteCheckBox.Checked;

            ReturnValue = obj;
        }

        // User declined form:
        private void DialogCancelButton_Click(object sender, EventArgs e)
        {
            ReturnValue = null;
        }

        // Handle dynamic help message:

        private void SetHelpText(string text)
        {
            HelpLabel.Text = text;
            HelpLabel.Visible = true;
        }

        private void HideHelp()
        {
            HelpLabel.Visible = false;
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.NameHelpText);
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void DescriptionTextBox_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.DescriptionHelpText);
        }

        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void CategoryListComboBox_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.CategoryHelpText);
        }

        private void CategoryListComboBox_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void CompleteCheckBox_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.CompleteHelpText);
        }

        private void CompleteCheckBox_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void NoDateTask_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.NoDateHelpText);
        }

        private void NoDateTask_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void StartDatePicker_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.StartDateHelpText);
        }

        private void StartDatePicker_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }

        private void EndDatePicker_Enter(object sender, EventArgs e)
        {
            SetHelpText(ResourceTaskForm.EndDateHelpText);
        }

        private void EndDatePicker_Leave(object sender, EventArgs e)
        {
            HideHelp();
        }
    }
}
