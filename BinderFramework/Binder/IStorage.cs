using System.Windows.Forms;

namespace Binder
{
    public interface IStorage
    {
        object StorageAccess
        {
            get;
            set;
        }
        DataGridView Tab
        {
            get;
            set;
        }
        ITask Task
        {
            get;
            set;
        }
        void SaveToStorage();
        void LoadFromStorage();
    }
}
