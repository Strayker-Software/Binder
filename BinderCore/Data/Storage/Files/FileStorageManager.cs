using System;
using System.Collections.Generic;
using System.IO;
using Binder.Properties;

namespace Binder.Data.Storage.Files
{
    /// <summary>
    /// Class for data access in file system. Only local files for now.
    /// </summary>
    public class FileStorageManager : IStorage
    {
        private List<string> StorageData;
        private string LocationPath;
        private readonly IFileSystemAccess fileSystemAccess;

        /// <summary>
        /// Directory to file with data. Can't be null or empty.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public object Location
        {
            get { return LocationPath; }
            set
            {
                if (string.IsNullOrEmpty((string)value))
                    throw new ArgumentException("Value can't be null or empty.");

                if (!fileSystemAccess.Exists((string)value))
                    throw new FileNotFoundException("There's no file under this directory.");

                LocationPath = (string)value;
            }
        }

        public StorageType Type
        {
            get { return StorageType.File; }
        }

        /// <summary>
        /// Constructor for making sure, that <see cref="FileStorageManager"/> always has location set.
        /// </summary>
        /// <param name="access"><see cref="IFileSystemAccess"/> object, providing access to user's file system.</param>
        /// <param name="path"><see cref="string"/> object with full path to file with extencion.</param>
        /// <exception cref="ArgumentException"></exception>
        public FileStorageManager(IFileSystemAccess access, string path)
        {
            fileSystemAccess = access ?? throw new NullReferenceException("Object for file system access is null.");

            if (fileSystemAccess.Exists(path))
                Location = path;
            else throw new ArgumentException("Error with path provided: empty or invalid.");

            ClearStorage();
        }

        /// <summary>
        /// Loads single data string from storage memory, load is performed at specified line in index.
        /// </summary>
        /// <param name="index">Line in storage file, specifies which line to load. Between 0 and data count.</param>
        /// <returns><see langword="String" /> object with requested data. <see cref="null"/> if error.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string LoadFromStorage(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Wrong index value. Must be greater than -1.");

            try
            {
                return StorageData[index];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Loads all data from storage memory and returns it.
        /// </summary>
        /// <returns><see cref="List{string}"/> object with all data from storage. <see cref="null"/> if nothing to load</returns>
        public IList<string> LoadFromStorage()
        {
            return StorageData;
        }

        /// <summary>
        /// Saves given data at the specified index. Data is moved in memory respectively.
        /// </summary>
        /// <param name="index"><see cref="int"/> with destination, where in the memory should be located data.</param>
        /// <param name="data"><see cref="string"/> with data to save.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>Warning: Can overload existing data at given index.</remarks>
        public void SaveToStorage(int index, string data)
        {
            try
            {
                StorageData.Insert(index, data);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Wrong index value. Must be greater than -1.");
            }
        }

        public void SaveToStorage(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Value can't be null or empty.");

            StorageData.Add(data);
        }

        /// <summary>
        /// Saves all given data to storage memory, depending on option specified.
        /// </summary>
        /// <param name="mode"><see cref="StorageSaveMode"/> option for specifing operation to perform.</param>
        /// <param name="data"><see cref="IList{string}"/> object filled with <see cref="string"/> objects.</param>
        /// <exception cref="ArgumentException"></exception>
        public void SaveToStorage(StorageSaveMode mode, IList<string> data)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("Data list can't be null or empty.");

            switch (mode)
            {
                case StorageSaveMode.Overwrite:
                    ClearStorage();
                    StorageData.AddRange(data);

                    break;

                case StorageSaveMode.Append:
                    StorageData.AddRange(data);

                    break;

                case StorageSaveMode.None: break;
            }
        }

        public void ClearStorage()
        {
            StorageData = new List<string>
            {
                Settings.Default.DefaultStorageSetting
            };
        }

        public void RemoveFromStorage(int index)
        {

        }

        public void RemoveFromStorage(string data)
        {

        }

        /// <summary>
        /// Reload data from storage to memory and from memory to storage, depending on argument.
        /// </summary>
        /// <inheritdoc/>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        public void FlushStorage(StorageFlushMode mode)
        {
            switch (mode)
            {
                case StorageFlushMode.Save:
                    fileSystemAccess.Delete((string)Location);

                    using (var stream = fileSystemAccess.GetFileStreamWriter((string)Location))
                    {
                        foreach (string data in StorageData)
                            stream.WriteLine(data);
                    }

                    break;

                case StorageFlushMode.Load:
                    ClearStorage();

                    using (var stream = fileSystemAccess.GetFileStreamReader((string)Location))
                    {
                        string data = stream.ReadLine();
                        while (data != null)
                        {
                            StorageData.Add(data);
                            data = stream.ReadLine();
                        } 
                    }

                    break;

                case StorageFlushMode.None: break;
            }
        }
    }
}
