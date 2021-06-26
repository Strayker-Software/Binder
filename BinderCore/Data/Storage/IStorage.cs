using System.Collections.Generic;

namespace Binder.Data.Storage
{
    public enum StorageType
    {
        File,
        DB,
        Undefined
    }

    /// <summary>
    /// Enumeration for setting flush mode of storage.
    /// </summary>
    public enum StorageFlushMode
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
    /// Enumeration for setting saving mode for storage buffer interaction.
    /// </summary>
    public enum StorageSaveMode
    {
        /// <summary>
        /// Overwrite existing data in buffer.
        /// </summary>
        Overwrite,
        /// <summary>
        /// Append new data after old ones in buffer.
        /// </summary>
        Append,
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
        /// Type of storage manager.
        /// </summary>
        StorageType Type
        {
            get;
        }

        /// <summary>
        /// Saves given string to storage, at given index.
        /// </summary>
        /// <param name="index">Integer for index of data array in storage.</param>
        /// <param name="data">String object with data to save.</param>
        void SaveToStorage(int index, string data);

        /// <summary>
        /// Appends given data to the end of storage buffer.
        /// </summary>
        /// <param name="data"><see cref="string"/> object with data to append.</param>
        void SaveToStorage(string data);

        /// <summary>
        /// Method to perform save operation on many data strings.
        /// </summary>
        void SaveToStorage(StorageSaveMode mode, IList<string> data);

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
        /// 
        /// </summary>
        void ClearStorage();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        void RemoveFromStorage(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void RemoveFromStorage(string data);

        /// <summary>
        /// Method to reload data from or to storage.
        /// </summary>
        /// <param name="mode"><see cref="StorageFlushMode"/> option, specifying operation to perform.</param>
        void FlushStorage(StorageFlushMode mode);
    }
}
