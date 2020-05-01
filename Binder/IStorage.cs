using System.Windows.Forms;

namespace Binder
{
    public interface IStorage
    {
        string StoragePath
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
