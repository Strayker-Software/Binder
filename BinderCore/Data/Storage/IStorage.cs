using System.Collections.Generic;

namespace Binder.Data.Storage
{
    /// <summary>
    /// Interface for creation of new storage managment classes.
    /// </summary>
    public interface IStorage
    {
        object Location
        {
            get;
            set;
        }

        /// <summary>
        /// Method to perform save operation on single data string.
        /// </summary>
        void SaveToStorage(string data);

        /// <summary>
        /// Method to perform save operation on many data strings.
        /// </summary>
        void SaveToStorage(IList<string> data);

        /// <summary>
        /// Method to perform load operation. All data from storage will be loaded.
        /// </summary>
        /// <returns>One-dimensional array, containing all data from selected storage.</returns>
        IList<string> LoadFromStorage();
    }
}
