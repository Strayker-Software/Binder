using System.Collections.Generic;
using Binder.Storage;
using Binder.Task;
using Binder.UI;
using Binder.UI.Dialog;

namespace Binder.Controllers
{
    public interface IController
    {
        IList<ICategory> Categories
        {
            get;
        }

        IDialog DataInputDialog
        {
            get;
        }

        IForm ActiveForm
        {
            get;
        }

        IStorage ActiveStorage
        {
            get;
        }

        ITask QueryTask(string taskName);

        ICategory QueryCategory(string categoryName);

        void LoadApp();

        void ChangeSelectedCategory(ICategory selectedCategory);

        void ChangeSelectedTask(ITask selectedTask);

        void AddCategory();

        void RenameCategory();

        void DeleteCategory();

        void ShowCompletedTaskList();

        void HideCompletedTaskList();

        void AddTask();

        void EditTask();

        void DeleteTask();

        void SaveCategory();

        void SaveAll();

        void ShowSettings();

        void ShowAboutWindow();

        void LoadNewSettings(IStorage newStorage);

        void LoadNewSettings(IForm newForm);

        void CloseApp();
    }
}
