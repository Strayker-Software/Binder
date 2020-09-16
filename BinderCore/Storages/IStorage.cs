using Binder.Tasks;

namespace Binder.Storages
{
    /// <summary>
    /// Interface for creation of new storage managment classes.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Object responsible for accessing data area.
        /// </summary>
        object StorageAccess
        {
            get;
            set;
        }
        /// <summary>
        /// Table with data for manager.
        /// </summary>
        object DataDisplay
        {
            get;
            set;
        }
        /// <summary>
        /// ITask inherited class for task support in manager.
        /// </summary>
        ITask Task
        {
            get;
            set;
        }
        /// <summary>
        /// Method to perform save operation.
        /// </summary>
        void SaveToStorage();
        /// <summary>
        /// Method to perform load operation.
        /// </summary>
        void LoadFromStorage();
    }
}
