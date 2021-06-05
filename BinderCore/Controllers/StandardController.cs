using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Binder.Properties;
using Binder.Data.Storage;
using Binder.Task;
using Binder.Task.Factories;
using Binder.UI;
using Binder.UI.Dialog;
using Binder.UI.MessageBoxes;

namespace Binder.Controllers
{
    public class StandardController : IController
    {
        // Factories:
        private readonly ICategoryFactory categoryFactory = new CategoryFactory();
        private readonly IDialogFactory dialogFactory = new DialogFactory();
        private readonly IMessageBoxFactory messageBoxFactory = new MessageBoxFactory();

        private IList<ICategory> categoriesList;
        private IDialog dataInput;
        private IForm activeForm;
        private IStorage activeStorage;

        public IList<ICategory> Categories
        {
            get { return categoriesList; }
            private set
            {
                categoriesList = value;
            }
        }

        public IDialog DataInputDialog
        {
            get { return dataInput; }
            private set
            {
                dataInput = value;
            }
        }

        public IForm ActiveForm
        {
            get { return activeForm; }
            private set
            {
                activeForm = value;
            }
        }

        public IStorage ActiveStorage
        {
            get { return activeStorage; }
            private set
            {
                activeStorage = value;
            }
        }

        public StandardController(IForm form, IStorage storage)
        {
            ActiveStorage = storage;
            ActiveForm = form;
            Categories = new List<ICategory>();
            DataInputDialog = dialogFactory.GetDialog(EDialog.StringInput);

            ActiveForm.SetController(this);
        }

        public ITask QueryTask(string taskName)
        {
            foreach (ICategory category in Categories)
            {
                foreach(ITask task in category.Tasks)
                {
                    if (taskName == task.Name)
                        return task;
                }    
            }

            return null;
        }

        public ICategory QueryCategory(string categoryName)
        {
            foreach (ICategory category in Categories)
            {
                if (category.Name == categoryName)
                    return category;
            }

            return null;
        }

        public void AddCategory()
        { // TODO: Untestable, rewrite for unit testing.
            // Ask user for category data:
            DataInputDialog = dialogFactory.GetDialog(EDialog.StringInput, Resources.CategoryNameInputDialogText);
            DataInputDialog.AskUser();

            if (DataInputDialog.IsDataProvided())
            {
                var addedCategory = categoryFactory.GetCategory(ECategory.Standard);
                addedCategory.Name = (string)DataInputDialog.ReturnValue;
                addedCategory.Tasks = new List<ITask>();

                // Check if user tries to add category that already exists:
                var equalSearchCategory = QueryCategory((string)DataInputDialog.ReturnValue);
                if (equalSearchCategory != null)
                {
                    messageBoxFactory.ShowMessageBox(
                        EMessageBox.Standard,
                        Resources.CategoryAlreadyExistsErrorMessage,
                        Settings.Default.AppName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                Categories.Add(addedCategory);
                Settings.Default.Categories.Add(addedCategory.Name);
                Settings.Default.Save();
                ActiveForm.AddCategoryToDisplay(addedCategory);

                // TODO: Prepare storage access for new categories!
            }
            else
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoDataProvidedErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var dialog = (Form)DataInputDialog;
            dialog.Dispose();
        }

        public void ShowCompletedTaskList()
        {
            var result = QueryCategory(Resources.CompletedTaskListText);
            ActiveForm.AddCategoryToDisplay(result);
        }

        public void HideCompletedTaskList()
        {
            var result = QueryCategory(Resources.CompletedTaskListText);
            ActiveForm.DeleteCategoryFromDisplay(result);
        }

        public void AddTask()
        { // TODO: Untestable, rewrite for unit testing.
            // Ask user for category data:
            DataInputDialog = dialogFactory.GetDialog(EDialog.StandardTask);
            DataInputDialog.AskUser();

            if (DataInputDialog.IsDataProvided())
            {
                var tsk = (ITask)DataInputDialog.ReturnValue;

                // Look for proper category in memory to add new task, after that - display it:
                foreach (var item in Categories)
                {
                    // Check if task provided already exists in this category:
                    if(item.Tasks.Contains(tsk))
                    {
                        messageBoxFactory.ShowMessageBox(
                            EMessageBox.Standard,
                            string.Format(Resources.TaskAlreadyExistsErrorMessage, item.Name),
                            Settings.Default.AppName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    if (tsk.Complete)
                    {
                        if (item.Name == Resources.CompletedTaskListText)
                            item.Tasks.Add(tsk);
                        else continue;

                        break;
                    }
                    else
                    {
                        if (item.Name == tsk.Category)
                            item.Tasks.Add(tsk);
                        else continue;

                        break;
                    }
                }

                ActiveForm.AddTaskToDisplay(tsk);
            }
            else
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoDataProvidedErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var dialog = (Form)DataInputDialog;
            dialog.Dispose();
        }

        public void ChangeSelectedCategory(ICategory selectedCategory)
        {
            ActiveForm.SetCurrentCategorySelected(selectedCategory);
        }

        public void ChangeSelectedTask(ITask selectedTask)
        {
            ActiveForm.SetCurrentTaskSelected(selectedTask);
        }

        public void CloseApp()
        {
            // TODO: Save data from all categories to storage.

            // Close all app's windows:
            foreach (Form appForm in Application.OpenForms)
            {
                if (appForm == (Form)ActiveForm) continue;

                appForm.Close();
            }

            Environment.Exit(0);
        }

        public void DeleteCategory()
        { // TODO: Untestable, rewrite for unit testing.
            var categoryName = ActiveForm.GetCurrentSelectedCategoryName();
            var selectedCategory = QueryCategory(categoryName);

            // Check if user tries to delete special categories (default and complete):
            if (selectedCategory.Name == Resources.CompletedTaskListText || selectedCategory.Name == Resources.DefaultTaskCategoryName)
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.DeleteSpecialListErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var result = messageBoxFactory.ShowMessageBox(
                EMessageBox.Standard,
                Resources.ConfirmCategoryDeleteMessage,
                Settings.Default.AppName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Remove selected category from display, settings and memory:
                ActiveForm.DeleteCategoryFromDisplay(selectedCategory);
                Settings.Default.Categories.Remove(selectedCategory.Name);
                Settings.Default.Save();
                Categories.Remove(selectedCategory);

                // TODO: Remove category from storage!
            }
        }

        public void DeleteTask()
        { // TODO: Untestable, rewrite for unit testing.
            var selectedTaskName = ActiveForm.GetCurrentSelectedTaskName();

            if(selectedTaskName == null)
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoRowSelectedErrorMessage,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var result = messageBoxFactory.ShowMessageBox(
                EMessageBox.Standard,
                Resources.ConfirmTaskDeleteMessage,
                Settings.Default.AppName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Remove selected task from display and memory:
                var selectedTask = QueryTask(selectedTaskName);
                ActiveForm.DeleteTaskFromDisplay(selectedTask);
                foreach (var category in Categories)
                {
                    // Look for category of task:
                    if (category.Name == selectedTask.Category)
                    {
                        category.Tasks.Remove(selectedTask);
                        return;
                    }
                }
            }
        }

        public void EditTask()
        { // TODO: Untestable, rewrite for unit testing.
            var oldTaskName = ActiveForm.GetCurrentSelectedTaskName();

            if(oldTaskName == null)
            {
                messageBoxFactory.ShowMessageBox(
                        EMessageBox.Standard,
                        Resources.NoRowSelectedErrorMessage,
                        Settings.Default.AppName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                return;
            }

            var selectedTask = QueryTask(oldTaskName);

            DataInputDialog = dialogFactory.GetDialog(EDialog.StandardTask, selectedTask);
            DataInputDialog.AskUser();

            if(DataInputDialog.IsDataProvided())
            {
                var newTask = (ITask)DataInputDialog.ReturnValue;

                // Is new task and old task the same:
                if(selectedTask.Equals(newTask))
                {
                    messageBoxFactory.ShowMessageBox(
                        EMessageBox.Standard,
                        Resources.EditedTaskStillTheSameErrorMessage,
                        Settings.Default.AppName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                ICategory category;
                // Delete task from old category:
                if (selectedTask.Complete)
                    category = QueryCategory(Resources.CompletedTaskListText);
                else category = QueryCategory(selectedTask.Category);
                category.Tasks.Remove(selectedTask);

                // Add task to new category:
                if (newTask.Complete)
                    category = QueryCategory(Resources.CompletedTaskListText);
                else category = QueryCategory(newTask.Category);
                category.Tasks.Add(newTask);

                ActiveForm.EditTaskInDisplay(newTask, selectedTask);
            }
            else
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoDataProvidedErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var dialog = (Form)DataInputDialog;
            dialog.Dispose();
        }

        public void LoadApp()
        {
            ActiveForm.ClearDisplay();
            var obj = categoryFactory.GetCategory(ECategory.Standard);

            // Add extra tab for default task list:
            obj.Name = Resources.DefaultTaskCategoryName;
            obj.Tasks = new List<ITask>();
            Categories.Add(obj);
            ActiveForm.AddCategoryToDisplay(obj);

            // Add extra tab for completed task list, but don't show it to user:
            obj = categoryFactory.GetCategory(ECategory.Standard);
            obj.Name = Resources.CompletedTaskListText;
            obj.Tasks = new List<ITask>();
            Categories.Add(obj);

            // Create all categories to tab controller:
            foreach (string item in Settings.Default.Categories)
            {
                obj = categoryFactory.GetCategory(ECategory.Standard);
                obj.Name = item;
                obj.Tasks = new List<ITask>();

                // TODO: Storage should load tasks to this list.

                Categories.Add(obj);
                ActiveForm.AddCategoryToDisplay(obj);
            }
        }

        public void RenameCategory()
        { // TODO: Untestable, rewrite for unit testing.
            var selectedCategoryName = ActiveForm.GetCurrentSelectedCategoryName();

            // Check if user tries to change name of special categories:
            if (selectedCategoryName == Resources.CompletedTaskListText || selectedCategoryName == Resources.DefaultTaskCategoryName)
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.RenameSpecialListErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Ask user for new category name:
            DataInputDialog = dialogFactory.GetDialog(EDialog.StringInput, Resources.RenameCategoryDialogText);
            DataInputDialog.AskUser();

            if(DataInputDialog.IsDataProvided())
            {
                var newCategoryName = (string)DataInputDialog.ReturnValue;
                var categoryToBeRenamed = QueryCategory(selectedCategoryName);

                // Change category name to new one in settings, display and memory:
                foreach (var category in Categories)
                {
                    if(category.Name == selectedCategoryName)
                    {
                        var index = Settings.Default.Categories.IndexOf(selectedCategoryName);
                        Settings.Default.Categories.RemoveAt(index);
                        Settings.Default.Categories.Add(newCategoryName);
                        Settings.Default.Save();

                        ActiveForm.RenameCategoryInDisplay(categoryToBeRenamed, newCategoryName);
                        category.Name = newCategoryName;
                        break;
                    }
                }
            }
            else
            {
                messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.NoDataProvidedErrorText,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var dialog = (Form)DataInputDialog;
            dialog.Dispose();
        }

        public void ShowSettings()
        {
            messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.WorkInProgressMessage,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public void ShowAboutWindow()
        {
            messageBoxFactory.ShowMessageBox(
                    EMessageBox.Standard,
                    Resources.WorkInProgressMessage,
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public void SaveCategory()
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void LoadNewSettings(IStorage newStorage)
        {
            throw new NotImplementedException();
        }

        public void LoadNewSettings(IForm newForm)
        {
            throw new NotImplementedException();
        }
    }
}
