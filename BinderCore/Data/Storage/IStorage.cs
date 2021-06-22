using System.Collections.Generic;

namespace Binder.Data.Storage
{
    /// <summary>
    /// Enumeration for setting refresh mode of storage.
    /// </summary>
    public enum StorageRefreshMode
    {
        /// <summary>
        /// Saving mode - memory to storage.
        /// </summary>
        Save,
        /// <summary>
        /// Loading mode - storage to memory.
        /// </summary>
        Load,
        None
    }

    /// <summary>
    /// Interface for creation of new storage managment classes.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Location property for storage access.
        /// </summary>
        object Location
        {
            get;
            set;
        }

        /// <summary>
        /// Saves given string to storage, at given index.
        /// </summary>
        /// <param name="index">Integer for index of data array in storage.</param>
        /// <param name="data">String object with data to save.</param>
        void SaveToStorage(int index, string data);

        /// <summary>
        /// Method to perform save operation on many data strings.
        /// </summary>
        void SaveToStorage(IList<string> data);

        /// <summary>
        /// Loads data from given index to string object.
        /// </summary>
        /// <param name="index">Integer for index of data array in storage.</param>
        /// <returns><see cref="string"/> object with loaded data.</returns>
        string LoadFromStorage(int index);

        /// <summary>
        /// Method to perform load operation. All data from storage will be loaded.
        /// </summary>
        /// <returns><see cref="IList{string}"/>, containing all data from selected storage.</returns>
        IList<string> LoadFromStorage();

        /// <summary>
        /// Method to reload data from or to storage.
        /// </summary>
        /// <param name="mode"><see cref="StorageRefreshMode"/> option, specifying operation to perform.</param>
        void RefreshStorage(StorageRefreshMode mode);
    }
}
