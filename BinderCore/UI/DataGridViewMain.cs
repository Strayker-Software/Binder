#if DEBUG
using System.IO;
#endif
using System;
using System.Windows.Forms;
using Binder.Controllers;
using Binder.Task;
using Binder.Properties;
using Binder.Properties.Languages;
using Binder.UI.MessageBoxes;

namespace Binder.UI
{
    public partial class DataGridViewMain : Form, IForm
    {
        private readonly IMessageBoxFactory messageBoxFactory = new MessageBoxFactory();
        private IController controller;

        /// <summary>
        /// Main class constructor.
        /// </summary>
        public DataGridViewMain()
        {
            InitializeComponent();
            // TODO: Move this instructions to IDE.
#if DEBUG
            DevLabel.Text = string.Format(Resources.DebugBuildMessage, Application.ProductVersion);
            DevLabel.Visible = true;
            Settings.Default.Reset();
            foreach (string x in Directory.GetFiles(Settings.Default.DefaultDirectory))
            {
                File.Delete(x);
            }
            var stream = File.CreateText(Settings.Default.DefaultCategoryFileDirectory);
            stream.Write(Settings.Default.DefaultXMLStorageSetting);
            stream.Close();
#endif

            // Set localisation texts:
            Text = ResourceMainForm.FormTitle;

            ManagerToolStripMenuItem.Text = ResourceMainForm.CategoryManagerMenuText;
            DataToolStripMenuItem.Text = ResourceMainForm.DataManagerMenuText;
            HelpToolStripMenuItem.Text = ResourceMainForm.MiscMenuText;

            NewTabToolStripMenuItem.Text = ResourceMainForm.NewCategoryOptionText;
            DeleteTabToolStripMenuItem.Text = ResourceMainForm.DeleteCategoryOptionText;
            ShowHideCompletedTaskListMenuItem.Text = ResourceMainForm.ShowHideCompleteTaskListText;
            SaveToolStripMenuItem.Text = ResourceMainForm.SaveOptionText;
            SaveAllToolStripMenuItem.Text = ResourceMainForm.SaveAllOptionText;
            ExitToolStripMenuItem.Text = ResourceMainForm.ExitOptionText;

            AddTaskToolStripMenuItem.Text = ResourceMainForm.AddTaskOptionText;
            EditTaskToolStripMenuItem.Text = ResourceMainForm.EditTaskOptionText;
            DeleteTaskToolStripMenuItem.Text = ResourceMainForm.DeleteTaskOptionText;

            SettingsToolStripMenuItem.Text = ResourceMainForm.SettingsOptionText;
            AboutAppToolStripMenuItem.Text = ResourceMainForm.AboutAppOptionText;
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.AddCategory();
        }

        private void DeleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.DeleteCategory();
        }

        private void ShowHideCompletedTaskListMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowHideCompletedTaskListMenuItem.Checked) controller.ShowCompletedTaskList();
            else controller.HideCompletedTaskList();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //controller.SaveCategory();
        }

        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //controller.SaveAll();
        }

        private void TabController_DoubleClick(object sender, EventArgs e)
        {
            controller.RenameCategory();
        }

        private void AboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ShowAboutWindow();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ShowSettings();
        }

        private void AddTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.AddTask();
        }

        private void EditTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EditTask();
            }
            catch (NullReferenceException)
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoRowSelectedErrorMessage,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.DeleteTask();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridViewMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = messageBoxFactory.ShowMessageBox(
                EMessageBox.Standard,
                Resources.ConfirmProgramExit,
                Settings.Default.AppName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                controller.CloseApp();
            else e.Cancel = true;
        }

        private void SetDGV(DataGridView tab)
        {
            tab.ColumnCount = 4;
            tab.Columns[0].HeaderText = ResourceMainForm.NameColumnText;
            tab.Columns[1].HeaderText = ResourceMainForm.DescriptionColumnText;
            tab.Columns[2].HeaderText = ResourceMainForm.StartDateColumnText;
            tab.Columns[3].HeaderText = ResourceMainForm.EndDateColumnText;
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tab.MultiSelect = false;
            tab.ReadOnly = true;
            tab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tab.AutoResizeColumns();
            tab.AllowUserToAddRows = false;
            tab.AllowUserToDeleteRows = false;
            tab.AllowUserToOrderColumns = false;
            tab.ShowCellToolTips = false;
        }

        public void ClearDisplay()
        {
            var display = TabController.TabPages;
            display.Clear();
        }

        public void AddCategoryToDisplay(ICategory category)
        {
            // Prepare DataGridView for data:
            var dgv = new DataGridView();
            SetDGV(dgv);

            // Prepare TabPage and add DataGridView to it:
            var page = new TabPage
            {
                Text = category.Name
            };
            dgv.Width = 200; // Why 200 px is more than 600? .NET Core bug? I have to check it...
            page.Controls.Add(dgv);
            TabController.TabPages.Add(page);

            // Add tasks for DataGridView:
            foreach (ITask task in category.Tasks)
            {
                AddTaskToDisplay(task);
            }
        }

        public void RenameCategoryInDisplay(ICategory category, string newName)
        {
            // Check if name is not null or empty:
            if (newName == string.Empty || newName == null)
                throw new ArgumentException("Value can't be null or empty.");

            // TODO: Move all exception info to dedicated resx file.

            // Search for given category in display and change it's name:
            foreach (TabPage page in TabController.TabPages)
            {
                if(page.Text == category.Name)
                {
                    page.Text = newName;
                    return;
                }    
            }
        }

        public void DeleteCategoryFromDisplay(ICategory category)
        {
            foreach (TabPage page in TabController.TabPages)
            {
                if (page.Text == category.Name)
                {
                    TabController.TabPages.Remove(page);
                    return;
                }
            }
        }

        public void AddTaskToDisplay(ITask task)
        {
            // Add completed task to correct list, but don't add it to main list:
            if (task.Complete && ShowHideCompletedTaskListMenuItem.Checked)
            {
                foreach (TabPage category in TabController.TabPages)
                {
                    if (category.Text == Resources.CompletedTaskListText)
                    {
                        var tab = (DataGridView)category.Controls[0];
                        var row = new DataGridViewRow();
                        row.CreateCells(tab);
                        if (task.EndDate == DateTime.MinValue)
                            row.SetValues(task.Name, task.Description, task.StartDate, ResourceMainForm.NoDeadlineDisplayText);
                        else row.SetValues(task.Name, task.Description, task.StartDate, task.EndDate);
                        tab.Rows.Add(row);
                        return;
                    }
                }
            }
            else if (task.Complete) return;

            // Search for the right category:
            foreach (TabPage category in TabController.TabPages)
            {
                if(category.Text == task.Category)
                {
                    var tab = (DataGridView)category.Controls[0];
                    var row = new DataGridViewRow();
                    row.CreateCells(tab);
                    if(task.EndDate == DateTime.MinValue)
                        row.SetValues(task.Name, task.Description, task.StartDate, ResourceMainForm.NoDeadlineDisplayText);
                    else row.SetValues(task.Name, task.Description, task.StartDate, task.EndDate);
                    tab.Rows.Add(row);
                    return;
                }
            }
        }

        public void EditTaskInDisplay(ITask newTask, ITask oldTask)
        {
            // Delete old task from display:
            DeleteTaskFromDisplay(oldTask);

            // Add new task to display:
            AddTaskToDisplay(newTask);
        }

        public void DeleteTaskFromDisplay(ITask task)
        {
            var tabpage = TabController.SelectedTab;
            var tab = (DataGridView)tabpage.Controls[0];

            // Search by name:
            foreach (DataGridViewRow item in tab.Rows)
            {
                if((string)item.Cells[0].Value == task.Name)
                    tab.Rows.Remove(item);
            }
        }

        public void SetCurrentTaskSelected(ITask task)
        {
            var index = TabController.TabPages.IndexOfKey(task.Category);
            var tab = (DataGridView)TabController.TabPages[index].Controls[0];

            // Search by name:
            foreach (DataGridViewRow item in tab.Rows)
            {
                if ((string)item.Cells[0].Value == task.Name)
                    item.Selected = true;
            }
        }

        public void SetCurrentCategorySelected(ICategory category)
        {
            var index = TabController.TabPages.IndexOfKey(category.Name);
            var cat = TabController.TabPages[index];

            cat.Select();
            cat.Focus();
        }

        public string GetCurrentSelectedTaskName()
        { // WARNING: This method takes currently selected task from active tabpage!
            var page = TabController.SelectedTab;

            if (page != null)
            {
                var tab = (DataGridView)page.Controls[0];
                var row = tab.SelectedRows[0];

                if (row.Cells.Count != 0)
                    return (string)row.Cells[0].Value;
                else return null;
            }
            else return null;
        }

        public string GetCurrentSelectedCategoryName()
        { // WARNING: This method takes currently selected task from active tabpage!
            var page = TabController.SelectedTab;

            if (page != null)
                return page.Text;
            else return null;
        }
    }
}
