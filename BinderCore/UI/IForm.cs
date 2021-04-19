using Binder.Controllers;
using Binder.Task;

namespace Binder.UI
{
    public interface IForm
    {
        void SetController(IController controller);

        void ClearDisplay();

        void AddCategoryToDisplay(ICategory category);

        void RenameCategoryInDisplay(ICategory category, string newName);

        void DeleteCategoryFromDisplay(ICategory category);

        void AddTaskToDisplay(ITask task);

        void EditTaskInDisplay(ITask newTask, ITask oldTask);

        void DeleteTaskFromDisplay(ITask task);

        void SetCurrentTaskSelected(ITask task);

        void SetCurrentCategorySelected(ICategory category);

        string GetCurrentSelectedTaskName();

        string GetCurrentSelectedCategoryName();
    }
}
