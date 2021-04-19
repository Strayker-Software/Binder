using Binder.Task;
using System.Collections.Generic;

namespace Binder.Storage
{
    /// <summary>
    /// Interface for creation of new storage managment classes.
    /// </summary>
    public interface IStorage
    {
        string Location
        {
            get;
            set;
        }

        /// <summary>
        /// Method to perform save operation.
        /// </summary>
        void SaveToStorage(ITask tsk);

        /// <summary>
        /// Method to perform load operation.
        /// </summary>
        IList<ICategory> LoadFromStorage();
    }
}
